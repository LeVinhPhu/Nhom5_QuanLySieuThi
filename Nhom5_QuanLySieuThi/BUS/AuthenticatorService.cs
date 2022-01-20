using Nhom5_QuanLySieuThi.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi.BUS
{
    public static class AuthenticatorService
    {
        private static string FileName = "sysconfig.dat";
        private static bool Serialize(string content)
        {
            RemoveSavedLogin();

            FileStream fileStream = new FileStream(FileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fileStream, content);
                FileInfo fileInfo = new FileInfo(FileName);
                fileInfo.IsReadOnly = true;
                return true;
            }
            catch (Exception) { }
            finally { fileStream.Close(); }
            return false;
        }

        public static void RemoveSavedLogin()
        {
            if (File.Exists(FileName))
            {
                File.SetAttributes(FileName, FileAttributes.Normal);
                File.Delete(FileName);
            }
        }

        public static bool SaveLogin(bool isCustomer, string phone, string password)
        {
            string preHash = phone + password;
            string hash = HashingService.ComputeSHA256(preHash);
            hash = (isCustomer) ? "C." + hash : "E." + hash;

            if (Serialize(hash))
                return true;
            return false;
        }


        private static string Deserialize()
        {
            File.SetAttributes(FileName, FileAttributes.Normal);
            FileStream fileStream = new FileStream(FileName, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            string prehash = null;
            try
            {
                prehash = (string)formatter.Deserialize(fileStream);
            }
            catch (Exception ex) { }
            finally 
            { 
                fileStream.Close(); 
                FileInfo fileInfo = new FileInfo(FileName);
                fileInfo.IsReadOnly = true;
            }

            return prehash;
        }


        public static bool TryLoggingIn()
        {
            if (File.Exists(FileName))
            {
                DAO_Authentication dAO_Authentication = new DAO_Authentication();
                try
                {
                    string str = Deserialize();
                    if (str == null)
                        throw new Exception();

                    string[] strs = str.Split('.');
                    string hash = null;
                    if (strs.Length > 1)
                        hash = strs[1];
                    else
                        throw new Exception();

                    switch (str.Split('.')[0])
                    {
                        case "E":
                            Employee employee = dAO_Authentication.TryMatchingEmployee(hash);
                            if (employee != null)
                            {
                                MessageBox.Show("emp");
                                GlobalConfigs.IsCustomer = false;
                                GlobalConfigs.PhoneNumber = employee.PhoneEmployee;
                                return true;
                            }
                            break;
                        case "C":
                            Customer customer = dAO_Authentication.TryMatchingCustomer(hash);
                            if (customer != null)
                            {
                                MessageBox.Show("cus");
                                GlobalConfigs.IsCustomer = true;
                                GlobalConfigs.PhoneNumber = customer.PhoneCustomer;
                                return true;
                            }
                            break;
                        default:
                            throw new FileLoadException();
                    }
                }
                catch (Exception)
                {
                    DialogResult dialogResult = MessageBox.Show("Saved Login detected but it is corrupted! Click OK to delete it", "Corrupted Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                        RemoveSavedLogin();

                }
            }
            return false;
        }
    }
}

using Nhom5_QuanLySieuThi.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nhom5_QuanLySieuThi
{
    // 
    public partial class FormHome : Form
    {
        public Communicator MainCommunicator { get; private set; }
        private Dictionary<Button, List<BoxView>> map = new Dictionary<Button, List<BoxView>>();
        private int originalCateforiesPanelWidth;
        private Boolean increasedSize = false;
        private BUS_SanPham bUS_SanPham = new BUS_SanPham();
        private Button previousCategory = null;
        private Button currentCategory;
        private string filter;

        public string Filter 
        { 
            get { return filter; }
            set 
            { 
                filter = value;
                OnCategoryMouseClick(currentCategory, null);
            }
        }

        public FormHome()
        {
            InitializeComponent();
            originalCateforiesPanelWidth = categoriesPanel.Width;
            UpdateCategories();
            MainCommunicator = Communicator.Instance;
            if (map.Count > 0)
                OnCategoryMouseClick(map.Keys.First(), null);
        }

        private bool MatchedFilter(BoxView boxView)
        {
            if (filter == null)
                return true;

            if (boxView.MainProduct.ProductName.ToLower().Contains(filter.ToLower()))
                return true;
            return false;
        }

        public void UpdateCategories()
        {
            // read from database
            map.Clear();
            bUS_SanPham.LoadCategories(map);
            categoriesPanel.Controls.Clear();

            ChangeCategoriesSizeToFit(map.Count);

            foreach (var key in map.Keys)
            {
                FormatCategory(key);
                key.MouseClick += new MouseEventHandler(OnCategoryMouseClick);
                categoriesPanel.Controls.Add(key);
            }
        }

        public void OnCategoryMouseClick(Object sender, MouseEventArgs eventArgs)
        {
            if (previousCategory != null)
            {
                previousCategory.BackColor = Color.FromArgb(206, 212, 218);
                previousCategory.ForeColor = Color.FromArgb(33, 37, 41);
            }

            previousCategory = sender as Button;
            currentCategory = sender as Button;
            (sender as Button).BackColor = Color.FromArgb(52, 58, 64);
            (sender as Button).ForeColor = Color.White;

            productsPanel.Controls.Clear();

            foreach(var boxView in map[sender as Button])
                if (MatchedFilter(boxView))
                    productsPanel.Controls.Add(boxView);

            if (productsPanel.Controls.Count == 0)
                MessageBox.Show("This category has NO product", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            filter = null;
        }


        private void FormatCategory(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(206, 212, 218);
            button.ForeColor = Color.FromArgb(33, 37, 41);
            button.Height = 50;
            button.Width = originalCateforiesPanelWidth - 6;
        }

        public void ChangeCategoriesSizeToFit(int size)
        {
            if (!increasedSize && categoriesPanel.Height - size * 50d < 0)
            {
                categoriesPanel.Width = originalCateforiesPanelWidth + 22;
                increasedSize = true;
            }
        }


        public void SyncChangesToOrderedProduct(OrderedProduct product)
        {
            Category category = bUS_SanPham.GetCategory(product.CategoryID);
            if (category != null)
            {
                foreach (var button in map.Keys)
                    if (button.Text.Equals(category.CategoryName))
                    {
                        for (int i = 0; i < map[button].Count; i++)
                        {
                            if (map[button][i].MainProduct.ProductID == product.ProductID)
                            {
                                map[button][i] = new BoxView(product);
                                OnCategoryMouseClick(button, null);
                                break;
                            }
                        }
                        break;
                    }
            }

           
        }


    }
}

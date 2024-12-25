using DOAN.DAO;
using DOAN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class frm_Admin : Form
    {
        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();

        public Account loginAccount;
        public frm_Admin()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadData()
        {
            data_Food.DataSource = foodList;
            data_Account.DataSource = accountList;

            LoadDateTimePickerBill();
            LoadListBillByDate(date_FromDate.Value, date_ToDate.Value);
            LoadListFood();
            LoadAccount();
            LoadCategoryIntoCombobox(cb_FoodCategory);
            AddFoodBinding();
            AddAccountBinding();
        }

        void AddAccountBinding()
        {
            txt_UserName.DataBindings.Add(new Binding("Text", data_Account.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txt_DisplayName.DataBindings.Add(new Binding("Text", data_Account.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nm_AccountType.DataBindings.Add(new Binding("Value", data_Account.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            date_FromDate.Value = new DateTime(today.Year, today.Month, 1);
            date_ToDate.Value = date_FromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            data_Bill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void AddFoodBinding()
        {
            txt_FoodName.DataBindings.Add(new Binding("Text", data_Food.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txt_IDFood.DataBindings.Add(new Binding("Text", data_Food.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nm_Price.DataBindings.Add(new Binding("Value", data_Food.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName) 
        { 
        if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        #endregion

        #region events
        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text;
            string displayName = txt_DisplayName.Text;
            int type = (int)nm_AccountType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text;

            DeleteAccount(userName);
        }

        private void btn_UpdateAccount_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text;
            string displayName = txt_DisplayName.Text;
            int type = (int)nm_AccountType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btn_ViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text;

            ResetPass(userName);
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txt_Sreach.Text);
        }
        private void txt_IDFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (data_Food.SelectedCells.Count > 0)
                {
                    int id = (int)data_Food.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cb_FoodCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cb_FoodCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cb_FoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }
        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            string name = txt_FoodName.Text;
            int categoryID = (cb_FoodCategory.SelectedItem as Category).ID;
            float price = (float)nm_Price.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btn_DeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_IDFood.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private void btn_UpdateFood_Click(object sender, EventArgs e)
        {
            string name = txt_FoodName.Text;
            int categoryID = (cb_FoodCategory.SelectedItem as Category).ID;
            float price = (float)nm_Price.Value;
            int id = Convert.ToInt32(txt_IDFood.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void Btn_ViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btn_ViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(date_FromDate.Value, date_ToDate.Value);
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        #endregion

        private void btn_FirstBillPage_Click(object sender, EventArgs e)
        {
            txt_PageBill.Text = "1";
        }

        private void btn_PrevioursBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(date_FromDate.Value, date_ToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txt_PageBill.Text = lastPage.ToString();
        }

        private void txt_PageBill_TextChanged(object sender, EventArgs e)
        {
            data_Bill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(date_FromDate.Value, date_ToDate.Value, Convert.ToInt32(txt_PageBill.Text));

        }

        private void btn_NextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txt_PageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(date_FromDate.Value, date_ToDate.Value);

            if (page < sumRecord)
                page++;

            txt_PageBill.Text = page.ToString();
        }

        private void btn_LastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(date_FromDate.Value, date_ToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txt_PageBill.Text = lastPage.ToString();
        }

        private void frm_Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet2.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
            //this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyQuanCafeDataSet2.USP_GetListBillByDateForReport, date_FromDate.Value, date_ToDate.Value);

            this.rp_Viewer.RefreshReport();
            
        }
    }
}

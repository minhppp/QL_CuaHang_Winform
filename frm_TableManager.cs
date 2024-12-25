using DOAN.DAO;
using DOAN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class frm_TableManager : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public frm_TableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cb_Combine);
        }

        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cb_FoodCategory.DataSource = listCategory;
            cb_FoodCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cb_Food.DataSource = listFood;
            cb_Food.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flow_Table.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flow_Table.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsv_Bill.Items.Clear();
            List<DOAN.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (DOAN.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsv_Bill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            lb_TotalPrice.Text = totalPrice.ToString("c", culture);

        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion
        #region Events

            void btn_Click(object sender, EventArgs e)
            {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsv_Bill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
            }
            private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
            {
            frm_AccountProfile f = new frm_AccountProfile(LoginAccount);
            f.UpdateAccount += frm_UpdateAccount;
            f.ShowDialog();
        }
            void frm_UpdateAccount(object sender, AccountEvent e)
            {
                thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
            }
            private void adminToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frm_Admin f = new frm_Admin();
                f.loginAccount = LoginAccount;
                f.InsertFood += frm_InsertFood;
                f.DeleteFood += frm_DeleteFood;
                f.UpdateFood += frm_UpdateFood;
                f.ShowDialog();
        }
            void frm_UpdateFood(object sender, EventArgs e)
            {
                LoadFoodListByCategoryID((cb_FoodCategory.SelectedItem as Category).ID);
                if (lsv_Bill.Tag != null)
                    ShowBill((lsv_Bill.Tag as Table).ID);
            }

            void frm_DeleteFood(object sender, EventArgs e)
            {
                LoadFoodListByCategoryID((cb_FoodCategory.SelectedItem as Category).ID);
                if (lsv_Bill.Tag != null)
                    ShowBill((lsv_Bill.Tag as Table).ID);
                LoadTable();
            }

            void frm_InsertFood(object sender, EventArgs e)
            {
                LoadFoodListByCategoryID((cb_FoodCategory.SelectedItem as Category).ID);
                if (lsv_Bill.Tag != null)
                    ShowBill((lsv_Bill.Tag as Table).ID);
            }

            private void cb_Category_SelectedIndexChanged(object sender, EventArgs e)
            {
                int id = 0;

                ComboBox cb = sender as ComboBox;

                if (cb.SelectedItem == null)
                    return;

                Category selected = cb.SelectedItem as Category;
                id = selected.ID;

                LoadFoodListByCategoryID(id);

            }
        private void btn_Add_Click(object sender, EventArgs e)
            {
                Table table = lsv_Bill.Tag as Table;

                if (table == null)
                {
                    MessageBox.Show("Hãy chọn bàn");
                    return;
                }

                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                int foodID = (cb_Food.SelectedItem as Food).ID;
                int count = (int)nmFoodCount.Value;

                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }

                ShowBill(table.ID);

                LoadTable();
            }
            

            private void btn_Check_Click(object sender, EventArgs e)
            {
            Table table = lsv_Bill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nm_Discount.Value;

            double totalPrice = Convert.ToDouble(lb_TotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }

        }
        private void btn_Combine_Click(object sender, EventArgs e)
        {
            int id1 = (lsv_Bill.Tag as Table).ID;

            int id2 = (cb_Combine.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsv_Bill.Tag as Table).Name, (cb_Combine.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

        #endregion

        
    }
        } 
  
    



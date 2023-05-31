using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=quanliktx;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Lấy dữ liệu cho table1 và hiển thị trong dataGridView1
                command = new SqlCommand("SELECT * FROM SINHVIEN", connection);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;



                connection.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentCell.RowIndex;
            MASV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            MAKTX.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            HO.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            TEN.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            CMND.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            GIOITINH.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            NGAYSINH.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            SDT.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            QUEQUAN.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            NGAYLAMHOPDONG.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            MAPHONG.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            loaddata();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO SINHVIEN (MASV, MAKTX, HO, TEN, CMND , GIOITINH , NGAYSINH , SDT , QUEQUAN , NGAYLAMHOPDONG , MAPHONG )" +
                "VALUES (@MASV,@MAKTX,@HO,@TEN,@CMND ,@GIOITINH ,@NGAYSINH ,@SDT ,@QUEQUAN ,@NGAYLAMHOPDONG ,@MAPHONG );";
                    command.Parameters.AddWithValue("@MASV", MASV.Text);
                    command.Parameters.AddWithValue("@MAKTX", MAKTX.Text);
                    command.Parameters.AddWithValue("@HO", HO.Text);
                    command.Parameters.AddWithValue("@TEN", TEN.Text);
                    command.Parameters.AddWithValue("@CMND", CMND.Text);
                    command.Parameters.AddWithValue("@GIOITINH", GIOITINH.Text);
                    command.Parameters.AddWithValue("@NGAYSINH", NGAYSINH.Text);
                    command.Parameters.AddWithValue("@SDT", SDT.Text);
                    command.Parameters.AddWithValue("@QUEQUAN", QUEQUAN.Text);
                    command.Parameters.AddWithValue("@NGAYLAMHOPDONG", NGAYLAMHOPDONG.Text);
                    command.Parameters.AddWithValue("@MAPHONG", MAPHONG.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NGAYLAMHOPDONG_TextChanged(object sender, EventArgs e)
        {

        }

        private void MAPHONG_TextChanged(object sender, EventArgs e)
        {

        }

        private void CMND_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM SINHVIEN WHERE MASV=@MASV";
                    command.Parameters.AddWithValue("@MASV", MASV.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE SINHVIEN SET MAKTX=@MAKTX, HO=@HO, TEN=@TEN, CMND=@CMND, GIOITINH=@GIOITINH, NGAYSINH=@NGAYSINH, SDT=@SDT, QUEQUAN=@QUEQUAN, NGAYLAMHOPDONG=@NGAYLAMHOPDONG, MAPHONG=@MAPHONG WHERE MASV=@MASV";
                        command.Parameters.AddWithValue("@MAKTX", MAKTX.Text);
                        command.Parameters.AddWithValue("@HO", HO.Text);
                        command.Parameters.AddWithValue("@TEN", TEN.Text);
                        command.Parameters.AddWithValue("@CMND", CMND.Text);
                        command.Parameters.AddWithValue("@GIOITINH", GIOITINH.Text);
                        command.Parameters.AddWithValue("@NGAYSINH", DateTime.Parse(NGAYSINH.Text)); // Chuyển đổi thành kiểu DateTime
                        command.Parameters.AddWithValue("@SDT", SDT.Text);
                        command.Parameters.AddWithValue("@QUEQUAN", QUEQUAN.Text);
                        command.Parameters.AddWithValue("@NGAYLAMHOPDONG", DateTime.Parse(NGAYLAMHOPDONG.Text)); // Chuyển đổi thành kiểu DateTime
                        command.Parameters.AddWithValue("@MAPHONG", MAPHONG.Text);
                        command.Parameters.AddWithValue("@MASV", MASV.Text);
                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể cập nhật thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

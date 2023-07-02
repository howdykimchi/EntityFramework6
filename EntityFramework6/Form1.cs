using EntityFramework6.Database;

namespace EntityFramework6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                lblStatus.Text = context.Database.Exists().ToString();
            }
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
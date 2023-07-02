using EntityFramework6.Database;
using EntityFramework6.Models;

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

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                //CRUD => DbSet
                //Create
                var school = new School { Name = "school1" };
                //context.Schools?.Add(school);
                context.Set<School>().Add(school);
                await context.SaveChangesAsync();

                var class1 = new Class { SchoolId = school.Id, Name = "class1" };
                var class2 = new Class { SchoolId = school.Id, Name = "class2" };
                //context.Classes?.Add(class1);
                //context.Classes?.Add(class2);
                context.Set<Class>().Add(class1);
                context.Set<Class>().Add(class2);
                await context.SaveChangesAsync();

                var student1 = new Student { ClassId = class1.Id, Name = "john", Birthday = "19601201" };
                var student2 = new Student { ClassId = class1.Id, Name = "sam", Birthday = "19630125" };
                var student3 = new Student { ClassId = class2.Id, Name = "casey", Birthday = "20001120" };
                //context.Students?.AddRange(new Student[] { student1, student2, student3 });
                context.Set<Student>().AddRange(new Student[] { student1, student2, student3 });
                await context.SaveChangesAsync();

                MessageBox.Show("saved");
            }

            /**
            select * from school s
            inner join class c on s.id = c.school_id
            inner join student st on c.id = st.class_id
            */
        }
    }
}
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

        private void btnRead_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                //var query = context.Schools?.AsQueryable();

                //select name from school
                //Method Syntax
                var schoolsQuery = context.Schools.Select(s => s.Name);
                var schools = schoolsQuery.ToList();
                //Query Syntax
                var schoolsQuery2 = from s in context.Schools
                                    select s.Name;
                var schools2 = schoolsQuery2.ToList();

                //select name AS MyName from school
                var schoolsQuery3 = from s in context.Schools
                                    select new { MyName = s.Name };

                //=================================================================================

                //select * from student where name = "sam";
                //Method Syntax
                var Query = from s in context.Students
                            where s.Name == "sam"
                            select s;
                var value = Query.ToList();

                //select * from student where name like "j%" // (like '%m') // (like '%a%')
                var Query2 = from s in context.Students
                             where s.Name.StartsWith("j") // EndsWith("m") // Contains("a")
                             select s;
                var value2 = Query2.ToList();

                //=================================================================================

                //select name, birthday from student where birthday >= '19930101' // (where birthday between '19930101' and '19950101')
                var Query3 = from s in context.Students
                             where string.Compare(s.Birthday, "19930101") >= 0 // && string.Compare(s.Birthday, "19950101") <= 0
                             select new { s.Name, s.Birthday };
                var value3 = Query3.ToList();

                //=================================================================================

                //select name, birthday from student where birthday in ('19940101', '19940201', '19950301')
                var birthdays = new List<string> { "19940101", "19940201", "19950301" };
                var Query4 = from s in context.Students
                             where birthdays.Contains(s.Birthday)
                             select new { s.Name, s.Birthday };
                var value4 = Query4.ToList();

                //=================================================================================

                //select name, birthday from student where name = 'sam' and (birthday = '19940101' OR  birthday = '19940201)'
                var Query5 = from s in context.Students
                             where s.Name == "sam" && (s.Birthday == "19940101" || s.Birthday == "19940201")
                             select new { s.Name, s.Birthday };
                var value5 = Query5.ToList();

                //=================================================================================

                //select top 10 name, birthday from student where birthday >= '19940201' order by birthday descending, name ascending;
                var Query6 = (from s in context.Students
                              where string.Compare(s.Birthday, "19940201") >= 0
                              orderby s.Birthday descending, s.Name
                              select new { s.Name, s.Birthday }).Take(10);
                //when using the 'Skip' method, it is necessary to include an 'orderby' clause.
                var value6 = Query6.ToList();

                //=================================================================================

                //select name, birthday from student where birthday >= '19940201' group by birthday class_id order by birthday descending, name ascending;
                var Query7 = from s in context.Students
                             where string.Compare(s.Birthday, "19940201") >= 0
                             orderby s.Birthday descending, s.Name
                             group s by s.ClassId into g
                             select new
                             {
                                 ClassId = g.Key,
                                 Count = g.Count(),
                                 Students = g.Select(s => new { s.Id, s.Name })
                             };
                var value7 = Query7.ToList();

                //=================================================================================

                //select c.name, s.name, s.birthday
                //from class c
                //inner join student s
                //where birthday >= '19940201'
                var Query8 = from c in context.Classes
                             join s in context.Students on c.Id equals s.ClassId
                             where string.Compare(s.Birthday, "19940201") > 0
                             select new
                             {
                                 ClassName = c.Name,
                                 StudentName = s.Name,
                                 StudentBirthday = s.Birthday,
                             };
                var value8 = Query8.ToList();

                //=================================================================================

                //select c.name, s.name, s.birthday
                //from class c
                //inner join student s
                //where birthday >= '19940201'

                var Query9 = from s in context.Students
                             where string.Compare(s.Birthday, "19940201") > 0
                             select new
                             {
                                 ClassName = s.Class == null ? "" : s.Class.Name,
                                 StudentName = s.Name,
                                 StudentBirthday = s.Birthday,
                             };
                var value9 = Query9.ToList();

                //=================================================================================

                //select c.name, s.name, s.birthday
                //from class c
                //left join student s
                //where birthday >= '19940201'
                var Query10 = from c in context.Classes
                              join s in context.Students on c.Id equals s.ClassId into joinedData
                              from jd in joinedData.DefaultIfEmpty()
                              where string.Compare(jd == null ? "" : jd.Birthday, "19940201") > 0
                              select new
                              {
                                  ClassName = c.Name,
                                  StudentName = jd == null ? "" : jd.Name,
                                  StudentBirthday = jd == null ? "" : jd.Birthday,
                              };
                var value10 = Query10.ToList();

                //=================================================================================

                //select c.id, c.name '' as birthday from class c
                //union all
                //select s.id, s.name, s.birthday from student s
                var Query11 = from c in context.Classes
                              select new { Id = c.Id, Name = c.Name, Birthday = "" };

                var Query11_2 = from s in context.Students
                                select new { s.Id, s.Name, s.Birthday };
                var unionQuery = Query11.Union(Query11_2);
                var value11 = unionQuery.ToList();

                //=================================================================================

                /*
                var schools = context.Set<School>().ToList();
                //select * from class
                var classes = context.Set<Class>().ToList();
                //select * from student where name like 's%'
                var students = context.Set<Student>().Where(st => st.Name.StartsWith("s")).ToList();
                foreach (var school in schools)
                {
                    Debug.WriteLine($"school name: {school.Name}, id: {school.Id}");
                }

                foreach (var c in classes)
                {
                    Debug.WriteLine($"class name: {c.Name}, id: {c.Id}");
                }

                foreach (var student in students)
                {
                    Debug.WriteLine($"student name: {student.Name}, id: {student.Id}");
                }
                */
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                //select * from student where id = 1
                Student student = context.Students.Find(1);
                MessageBox.Show($"{student.Id} / {student.Name} / {student.Birthday}");

                //update student set birthday = '20000101' where id = 1
                student.Birthday = "20000101";
                context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                Student updatedStudent = context.Students.Find(1);
                MessageBox.Show($"{updatedStudent.Id} / {updatedStudent.Name} / {updatedStudent.Birthday}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                Student student = context.Students.Find(2);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
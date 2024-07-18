using StudentRegistryApp.Pages.cs;

namespace StudentRegistryApp.Tests.cs
{
    public class AddStudentPageTests :BaseTests
    {
        [Test] 

        public void Test_TestAddStudentPage_Content()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(addStudentPage.GetPageTtitle(), Is.EqualTo("Add Student"));
                Assert.That(addStudentPage.GetPageHeadingtext(), Is.EqualTo("Register New Student"));
            });

            Assert.That(addStudentPage.FieldStudentName.Text, Is.EqualTo(string.Empty));
            Assert.That(addStudentPage.FieldStudentEmail.Text, Is.EqualTo(""));
            Assert.That(addStudentPage.ButtonAdd.Text, Is.EqualTo("Add"));               
        }

        [Test] 

        public void Tests_AddStudentPage_Links()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver); 
            addStudentPage.Open();

            addStudentPage.linkViewStudents.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);

            addStudentPage.linkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            addStudentPage.linkAddStudent.Click();
            Assert.That(addStudentPage.IsOpen(), Is.True);
        }

        [Test] 

        public void Tests_AddStudentPage_AddValidStudent ()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = GetRandomName();
            string email = GetRandomEmail(name);

            addStudentPage.AddStudent(name, email);
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);

            //var newStudentString = "name" + "(email)";
           
        }
        [Test] 

        public void Tests_AddStudentPage_InvalidStudent()
        {
            AddStudentPage studentAddPage = new AddStudentPage(driver);
            studentAddPage.Open();

            studentAddPage.AddStudent("", "aada@gmail.com");
            Assert.That(studentAddPage.IsOpen(), Is.True);
            Assert.That(studentAddPage.GetErrorMessage(), Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }

        public string GetRandomName()
        {
            Random random= new Random();
            string[] names = { "Pesho", "Gosho", "Koycho", "Gesho" };
            int randomNumber = random.Next(100, 999);
            string name = names[names.Length - 1] + randomNumber;
            return name;
        } 

        public string GetRandomEmail(string name)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000);
            string randomEmail = name + randomNumber + "@gmail.com";
            return randomEmail;
        }
    }
}

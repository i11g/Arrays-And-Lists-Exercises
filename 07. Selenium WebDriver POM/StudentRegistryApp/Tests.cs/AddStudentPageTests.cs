

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

    }
}

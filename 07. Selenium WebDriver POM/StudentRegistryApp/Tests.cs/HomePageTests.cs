
using StudentRegistryApp.Pages.cs;

namespace StudentRegistryApp.Tests.cs
{
    public class HomePageTests : BaseTests
    {
        [Test] 
        public void Tests_Home_Page_Content()
        {
            HomePage homepage = new HomePage(driver);
            homepage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(homepage.GetPageTtitle(), Is.EqualTo("MVC Example"));
                Assert.That(homepage.GetPageHeadingtext(), Is.EqualTo("Students Registry"));
            });

            Assert.True(homepage.StudentsCount() > 0);
        }

        [Test] 

        public void Test_Home_Page_Links ()
        {
            HomePage homepage = new HomePage(driver);
            homepage.Open();

            homepage.linkHomePage.Click();
            Assert.That(homepage.IsOpen(), Is.True);
            Assert.IsTrue(new HomePage(driver).IsOpen());

            homepage.linkViewStudents.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            homepage.linkAddStudent.Click();
            Assert.That(new AddStudentPage(driver).IsOpen(), Is.True);
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        } 

    }
}

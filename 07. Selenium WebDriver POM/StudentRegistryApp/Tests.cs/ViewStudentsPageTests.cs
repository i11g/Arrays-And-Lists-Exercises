

using StudentRegistryApp.Pages.cs;

namespace StudentRegistryApp.Tests.cs
{
    public class ViewStudentsPageTests :BaseTests
    {
        [Test] 
        public void Test_View_Students_Page_Content()
        {
            ViewStudentsPage studentPage = new ViewStudentsPage(driver);

            studentPage.Open();
            Assert.That(studentPage.GetPageTtitle(), Is.EqualTo("Students"));
            Assert.That(studentPage.GetPageHeadingtext, Is.EqualTo("Registered Students")); 

            var students=studentPage.GetRegisterStudents();

            foreach (var item in students)
            {
                Assert.IsTrue(item.IndexOf("(") > 0);
                Assert.That(item.LastIndexOf(")")==item.Length-1);
            }
        }
        
        [Test] 

        public void Tests_ViewStudentPage_Links()
        {
            ViewStudentsPage studentPage = new ViewStudentsPage(driver);
            studentPage.Open();

            studentPage.linkAddStudent.Click();
            Assert.That(new AddStudentPage(driver).IsOpen, Is.True);

            studentPage.linkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            studentPage.linkViewStudents.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);
;
        }

    }
}

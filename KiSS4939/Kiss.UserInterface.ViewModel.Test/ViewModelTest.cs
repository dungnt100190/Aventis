using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.UserInterface.ViewModel.Test
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void LoadMaskRight()
        {
            // Arrange
            var vm = new ViewModel();

            // Act
            vm.Init().Wait();

            // Assert
            var right = vm.Maskenrecht;

            Assert.IsTrue(right.CanDelete);
            Assert.IsTrue(right.CanInsert);
            Assert.IsTrue(right.CanUpdate);
        }
    }
}
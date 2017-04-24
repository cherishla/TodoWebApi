using NUnit.Framework;
using Todo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Todo.DAL;
using Telerik.JustMock;
using Todo.Service;
using FluentAssertions;

namespace Todo.Web.Controllers.Tests
{
    [TestFixture()]
    public class ToDoControllerTests
    {
        [Test()]
        public void GetAllItemsTest()
        {
            // Arrange
            var fixture = new Fixture();
            var expected = fixture.CreateMany<TodoItem>(20);

            var todoService = Mock.Create<ITodoService>();
            Mock.Arrange(() => todoService.GetAllItems()).ReturnsCollection(expected);

            // Act
            var controller = new ToDoController(todoService);
            var result = controller.GetAllItems();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Test()]
        public void GetUnFinishItemsTest()
        {
            // Arrange
            var fixture = new Fixture();
            var data1 = fixture.Build<TodoItem>()
                .With(x => x.IsFinish, true)
                .CreateMany(2);
            var data2 = fixture.Build<TodoItem>()
                .With(x => x.IsFinish, false)
                .CreateMany(3);
            var expected = data1.Concat(data2).ToList();

            var todoService = Mock.Create<ITodoService>();
            Mock.Arrange(() => todoService.GetAllItems()).ReturnsCollection(expected);

            // Act
            var controller = new ToDoController(todoService);
            var result = controller.GetUnFinishItems();

            // Assert
            result.Should().BeEquivalentTo(data2);
        }
    }
}
using NUnit.Framework;
using Todo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Todo.DAL;
using FluentAssertions;
using Ploeh.AutoFixture;

namespace Todo.Service.Tests
{
    [TestFixture()]
    public class TodoServiceTests
    {
        IToDoDbContext _db;

        [SetUp]
        public void Init()
        {
            this._db = Mock.Create<IToDoDbContext>();
        }
        [Test()]
        public void GetTodayIsDeadLineItemsTest()
        {
            //Arrange
            var expectDate = new DateTime(2017, 1, 1);
            var fixture = new Fixture();
            var todoItems = new List<TodoItem>();
            todoItems.Add(fixture.Build<TodoItem>().With(x => x.DeadLineOn, expectDate).Create());
            todoItems.Add(fixture.Build<TodoItem>().With(x => x.DeadLineOn, new DateTime(2017, 4, 20)).Create());
            todoItems.Add(fixture.Build<TodoItem>().With(x => x.DeadLineOn, new DateTime(2017, 4, 20)).Create());
            Mock.Arrange(() => _db.TodoItems).ReturnsCollection(todoItems);
            //Fake 假物件
            Mock.Arrange(() => DateTime.Now).Returns(expectDate);

            //Act
            var service = new TodoService(_db);
            var actual = service.GetTodayIsDeadLineItems();

            //Assert
            actual.Should().NotBeNullOrEmpty();
            actual.Count(x => x.DeadLineOn.Value.Date == expectDate).Should().Be(1);
        }
    }
}
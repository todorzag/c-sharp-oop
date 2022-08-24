using ToDoListProgram;

namespace ToDoListUnitTests
{
    public class ToDoListUnitTests
    {
        private ToDoList _defaultToDoList;

        [SetUp]
        public void Setup()
        {
            _defaultToDoList = new ToDoList();
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void Add_InputIsFalsy_ThrowException(string content)
        {
            Assert.Throws<ArgumentNullException>(() => _defaultToDoList.Add(content));
        }

        [Test]
        public void Add_InputIsValid_AddsToDo()
        {
            var dummyContent1 = "Buy bananas";
            var dummyContent2 = "Reformat code!";

            _defaultToDoList.Add(dummyContent1);
            Assert.That(_defaultToDoList.toDoList[0].Content, Is.EqualTo("Buy bananas"));
            
            _defaultToDoList.Add(dummyContent2);
            Assert.That(_defaultToDoList.toDoList[1].Content, Is.EqualTo("Reformat code!"));
        }

        [Test]
        public void IdCount_ToDoIsAdded_IdCounterPlusOne()
        {
            var dummyContent1 = "Buy bananas";
            int expectedIdCount1 = 1;

            var dummyContent2 = "Reformat code!";
            int expectedIdCount2 = 2;

            _defaultToDoList.Add(dummyContent1);
            Assert.That(_defaultToDoList.toDoList[0].Id, Is.EqualTo(expectedIdCount1));

            _defaultToDoList.Add(dummyContent2);
            Assert.That(_defaultToDoList.toDoList[1].Id, Is.EqualTo(expectedIdCount2));   
        }


        [TestCase("Valid Dummy Content")]
        public void IsCompleted_ToDoIsAdded_CompletedIsFalse(string stubString)
        {
            _defaultToDoList.Add(stubString);

            Assert.That(_defaultToDoList.toDoList[0].IsCompleted, Is.False);
        }

        [TestCase("Valid Dummy Content")]
        public void Complete_ToDoIsCompleted_CompletedIsTrue(string stubString)
        {
            _defaultToDoList.Add(stubString);

            _defaultToDoList.Complete(1);

            Assert.That(_defaultToDoList.toDoList[0].IsCompleted, Is.True);
        }

    }
}
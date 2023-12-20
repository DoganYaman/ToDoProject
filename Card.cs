namespace ToDoProject
{
    public class Card
    {
        private string _title;
        private string _content;
        private Person _person;
        private Size size;

        public string Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public Person Person { get => _person; set => _person = value; }
        public Size Size { get => size; set => size = value; }
    }
}
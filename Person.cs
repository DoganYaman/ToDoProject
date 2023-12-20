 namespace ToDoProject
 {
    public class Person
    {
        static Person()
        {
            _assignId = 1;
        }
        public Person()
        {
            _assignId ++;
        }
        private static int _assignId;
        private int _id = _assignId;
        private string _name;
        private string _surname;
        private Card _card = null;

        public int ID { get => _id; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public Card Card { get => _card; set => _card = value; }
        
    }
 }
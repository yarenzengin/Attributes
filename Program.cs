using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        { 
            Customer customer = new Customer { Id =1, LastName ="z" , Age= 12};
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);

        }
    }
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }//first name i girmek zorunda olsun
        public string LastName { get; set; }
        public int Age { get; set; }

    }
    class CustomerDal
  {
        [Obsolete("Don't use Add, instead use AddNew Method")]//hazır attribute/ kullanıcıyı uyardık
        public void Add(Customer customer)
        {
            Console.WriteLine("{0}, {1},{2},{3} added!" , customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0}, {1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

    }
    //nerede kullanacağımızı söyler // birden fazla yere uygulamak istediğimizde | bu işareti kullanıyoruz  
    //AllowMultiple bu attribute ü birden fazla kullanabilir miyim ? 
    [AttributeUsage(AttributeTargets.Property , AllowMultiple = true)]//bu attribute her yere kullanabilirsin
    class RequiredPropertyAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute : Attribute
    {
        string _tableName;

        public ToTableAttribute(string tableName)//gelen değer
        {
            _tableName = tableName;
        }
    }
    
}

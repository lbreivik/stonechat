using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HashTable;

namespace TestHashtable
{
    [TestFixture]
    public class TestMyHashtable
    {
        [Test]
        public void MyHashtable_Add5_succeeds()
        {
            var hashtbl = new MyHashtable<string, Person>(10);
            var p = new Person() { Name = "Louise", City = "Dublin" };
            var p2 = new Person() { Name = "Mary", City = "Dublin" };
            var p3 = new Person() { Name = "John", City = "Dublin" };
            var p4 = new Person() { Name = "Louise", City = "Cork" };
            var p5 = new Person() { Name = "Gary", City = "Galway" };

            hashtbl.Add(p.Name, p);
            hashtbl.Add(p2.Name, p2);
            hashtbl.Add(p3.Name, p3);
            hashtbl.Add(p4.Name, p4);
            hashtbl.Add(p5.Name, p5);

            Assert.AreEqual(hashtbl.Count(), 5);
        }

        [Test]
        public void MyHashtable_Add2_succeeds()
        {
            var hashtbl = new MyHashtable<string, Person>(10);
            var p = new Person() { Name = "Louise", City = "Dublin" };
            var p2 = new Person() { Name = "Mary", City = "Dublin" };

            hashtbl.Add(p.Name, p);
            hashtbl.Add(p2.Name, p2);

            Assert.AreEqual(hashtbl.Count(), 2);
        }

        [Test]
        public void MyHashtable_Add1_Find1_succeeds()
        {
            var hashtbl = new MyHashtable<string, Person>(10);
            var p = new Person() { Name = "Louise", City = "Dublin" };

            hashtbl.Add(p.Name, p);
            var result = hashtbl.Find(p.Name);

            Assert.AreEqual(result.Name, p.Name);
            Assert.AreEqual(result.City, p.City);

        }

        [Test]
        public void MyHashtable_Add2_Remove1_succeeds()
        {
            var hashtbl = new MyHashtable<string, Person>(10);
            var p = new Person() { Name = "Louise", City = "Dublin" };
            var p2 = new Person() { Name = "Mary", City = "Dublin" };

            hashtbl.Add(p.Name, p);
            hashtbl.Add(p2.Name, p2);

            hashtbl.Remove(p.Name);
            Assert.AreEqual(hashtbl.Count(), 1);

        }

        [Test]
        public void MyHashtable_Add2SameKey_Find1_succeeds()
        {
            var hashtbl = new MyHashtable<string, Person>(10);
            var p = new Person() { Name = "Louise", City = "Dublin" };
            var p2 = new Person() { Name = "Louise", City = "Cork" };

            hashtbl.Add(p.Name, p);
            hashtbl.Add(p2.Name, p2);

            var result = hashtbl.Find(p2.Name);

            Assert.AreEqual(result.City, p.City);
            Assert.AreEqual(result.Name, p.Name);

        }


        public class Person {
            public string Name { get; set; }
            public string City { get; set; }
        }

    }
}

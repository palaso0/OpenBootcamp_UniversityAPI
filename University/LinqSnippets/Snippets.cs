using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars =
            {
            "VW Golf",
            "VW California",
            "Audi A3",
            "Audi A5",
            "Fiat Punto",
            "Seat Ibiza",
            "Seat León"
        };

            //1 SELECT * of cars
            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SEKECT AUDIs)
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }
        //Number examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiplied by 3
            // take all numbers, but 9
            // Order numbers by ascending value
            var processedNumberList = numbers
                .Select(num => num * 3) //3,6,9,etc
                .Where(num => num != 0) //All but the 9
                .OrderBy(num => num); //Ordenar de forma ascendente

        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a","bx","c","d","e","cj","f","c"
            };
            //1 first of all emements
            var first = textList.First(); //Viene de IENUMERABLE, toma el primero de los ejemplos de la lista
            //2 First element that has "c"
            var cText = textList.First(text => text.Equals("c"));
            //3 First elemtn that contains j
            var jText = textList.First(text => text.Contains("j"));
            //4 First elemnt that contains Z or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); //Devuelve el primer elemento o un valor por defecto
            //5 Last element that contains "z"or default
            var last = textList.Last(text => text.Contains("z"));
            //6 single values
            var uniqueTexts = textList.Single();
            var uniqueDefaultTexts = textList.Single();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4, 8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }
        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };
            
            var myOpinionsSelection = myOpinions.SelectMany(opinion => opinion.Split(","));
            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@gmail.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@gmail.com",
                            Salary = 2000
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@gmail.com",
                            Salary = 500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@gmail.com",
                            Salary = 4000
                        },
                    }
                }
            };

            //Obtain all employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);
            
            //Know if a list is empty
            bool hasEnterprises = enterprises.Any(); //True si contiene elementos

            bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any());

            //All enterprises at least has an employee with at least than 1000E of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =  enterprises.Any(enterprise => 
                enterprise.Employees.Any(employee => 
                employee.Salary >= 1000));
        }
        static public void linCollections()
        {
            var firstList = new List<string>() {"a","b","c"};
            var secondList =  new List<string>() {"a","c","d"};

            //Inner Join
            var commonResult = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                select new {element, secondElement};

            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element,secondElement) => new {element, secondElement}
            );
            // Outer JOIN -Left
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new {Element = element};

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new {Element = element, secondElement};

            // Outer JOIN -Right
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new {Element = secondElement};

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void sKipTAkeLinq(){
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            // SKIP (Se salta valores)
            var skipFirstTwoValues  = myList.Skip(2); //3,4,5,6,7,8,9,10
            var skipLastTwu = myList.SkipLast(2); //1,2,3,4,5,6,7,8
            var skipWhileSmallerThanFour = myList.SkipWhile(num => num < 4); //4,5,6,7,8,9,10

            //Take (Sólo toma en cuenta)
            var takeFirstTwoValuew = myList.Take(2); // 1,2
            var takeLastTwoValues = myList.TakeLast(2); //9,10
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num<4); // 1,2,3
        }
    }
}




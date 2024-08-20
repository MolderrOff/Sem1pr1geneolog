/*
 Спроектируйте программу для построения 
генеалогического дерева. Учтите что у нас есть члены семьи у 
кого нет детей(дет). Есть члены семьи у кого дети есть 
(взрослые). Есть мужчины и женщины.

Доработать предыдущий класс реализовав методы вывода родителей, 
детей, братьев/сестер (включая двоюродных), бабушек и дедушек. 
Подумайте как лучше реализовать данные методы.

Доработайте приложение генеалогического дерева таким образом чтобы
программа выводила на экран близких родственников (жену/мужа). 
Продумайте способ более красивого вывода с использованием горизонтальных
и вертикальных черточек. (Мужа, жену, родителей и детей)
*/

using System;

namespace Sem1pr1geneolog
{
           
    public class Program
    {
        static void Main(string[] args)
        {
            FamilyMembers GrandFotherOfFother = new FamilyMembers()
            {
                FullName = "Иванов Иван Иванович",
                Age = 54,
                Gender = Gender.man
            };
            FamilyMembers GrandFotherOfMother = new FamilyMembers()
            {
                FullName = "Иванов Петр Петрович",
                Age = 51,
                Gender = Gender.man

            };
            FamilyMembers GrandMotherOfFother = new FamilyMembers()
            {
                FullName = "Петрова Мария Дмитриевна",
                Age = 60,
                Gender = Gender.woman,
                Husband = GrandFotherOfFother
            };
            FamilyMembers GrandMotherOfMother = new FamilyMembers()
            {
                FullName = "Смирнова Екатерина Ивановна",
                Age = 48,
                Gender = Gender.woman,
                Husband = GrandFotherOfMother
            };
            FamilyMembers Father = new FamilyMembers()
            {
                FullName = "Петров Кирилл Иванович",
                Age = 35,
                Gender = Gender.man,
                Mother = GrandMotherOfFother,
                Father = GrandFotherOfFother
            };
            FamilyMembers Mother = new FamilyMembers()
            {
                FullName = "Петрова Вера Ивановна",
                Age = 30,
                Gender = Gender.woman,
                Mother = GrandMotherOfMother,
                Father = GrandFotherOfMother,
                Husband = Father

            };
            FamilyMembers Son = new FamilyMembers()
            {
                FullName = "Петров Аркадий Кириллович",
                Age = 16,
                Gender = Gender.man,
                Mother = Mother,
                Father = Father
            };

            var GrandMothers = Son.GetGrandMotherName();
            Console.WriteLine($"Бабушка по маме> {GrandMothers[0]?.FullName}");
            Console.WriteLine($"Бабушка по отцу> {GrandMothers[1]?.FullName}");
            var Spouses = Mother.GetHusbandName();
            Console.WriteLine($"Супруги: жена: {Mother.FullName}, муж: {Spouses[0]?.FullName}");
            var Spouses2 = GrandMotherOfMother.GetHusbandName();
            Console.WriteLine($"Супруги: жена: {GrandMotherOfMother.FullName}, муж:  {Spouses2[0]?.FullName}");
            var Spouses3 = GrandMotherOfFother.GetHusbandName();
            Console.WriteLine($"Супруги: жена: {GrandMotherOfFother.FullName}, муж:  {Spouses3[0]?.FullName}");
            var ParentsSon = Son.GetParents();
            Console.WriteLine($"Родители: мать: {ParentsSon[0].FullName}, отец: {ParentsSon[1].FullName}");
            var ParentsMother = Mother.GetParents();
            Console.WriteLine($"Родители матери: мать: {ParentsMother[0].FullName}, отец: {ParentsMother[1].FullName}");
            var ParentsFather = Father.GetParents();
            Console.WriteLine($"Родители отца: мать: {ParentsFather[0].FullName}, отец: {ParentsFather[1].FullName}");
            
            FamilyMembers[] MasMembers = { GrandFotherOfFother, GrandFotherOfMother, GrandMotherOfFother, GrandMotherOfMother, Father, Mother, Son };
            FamilyMembers[] MasMembers1 = { GrandFotherOfFother, GrandFotherOfMother, GrandMotherOfFother, GrandMotherOfMother, Father, Mother, Son };

            Console.WriteLine("-----------");

            foreach (var item in MasMembers)
            {

                foreach (var item1 in MasMembers1)
                {
                    var ParentsX2 = item1?.GetParents();
                    if (ParentsX2[0] != null)
                    {
                        if (ParentsX2[0] == item)
                        {
                            Console.WriteLine($"Найдена связь: ребёнок {item1.FullName}, мать {item.FullName}, отец {item.Husband.FullName}");
                        }
                    }
                }
            }
            Console.WriteLine("-----------");

        }
    }
}

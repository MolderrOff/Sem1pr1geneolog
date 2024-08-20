using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1pr1geneolog
{
    public enum Gender //перечеисление
    {
        man,
        woman
    }
    ///<summary>
    ///<param>    
    ///Класс который задаёт свойства и методы членов семьи 
    ///<para>Age, Gender, FullName, Mother, Father</para>
    ///<para>GetGrandMotherName(), GetGrandFotherName()</para>
    ///</param>
    ///</summary>

    public class FamilyMembers
    {
        public int Age { get; set; } //свойство
        public Gender Gender { get; set; } //свойство
        public string FullName { get; set; } //свойство
        public FamilyMembers Mother { get; set; }
        public FamilyMembers Father { get; set; }
        public FamilyMembers Husband { get; set; }

        public FamilyMembers[] GetGrandMotherName() //метод
        {
            return new FamilyMembers[] { Mother?.Mother, Father?.Mother };
        }
        public FamilyMembers[] GetGrandFotherName()
        {
            return new FamilyMembers[] { Mother?.Father, Father?.Father };
        }
        public FamilyMembers[] GetHusbandName()
        {
            return new FamilyMembers[] { Husband };
        }
        public FamilyMembers[] GetParents()
        {
            return new FamilyMembers[] { Mother, Father};
        }

    }
}
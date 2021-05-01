using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediacedServer.Model
{
    public class Advertisement
    {
        public int id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String patronimic { get; set; }
        public String phoneNumber { get; set; }
        public String email { get; set; }
        public int age { get; set; }
        public String advText { get; set; }
        public float priceUSD { get; set; }
        public float courseOfUSD { get; set; }
        public float priceBYN { get; set; }


        public Advertisement(int id, String firstName, String lastName, String patronimic,
            String phoneNumber, String email, int age, String advText, float priceUSD,
            float courseOfUSD, float priceBYN)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.patronimic = patronimic;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.age = age;
            this.advText = advText;
            this.priceUSD = priceUSD;
            this.courseOfUSD = courseOfUSD;
            this.priceBYN = priceBYN;
        }

        public Advertisement()
        {
            this.id = 0;
            this.firstName = "";
            this.lastName = "";
            this.patronimic = "";
            this.phoneNumber = "";
            this.email = "";
            this.age = 0;
            this.advText = "";
            this.priceUSD = 0.0f;
            this.courseOfUSD = 0.0f;
            this.priceBYN = 0.0f;
        }

    }
}

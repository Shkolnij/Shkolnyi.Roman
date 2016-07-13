using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    
    class Client
    {
        private string name;
        private string familia;
        private int pinkod;
        private int balans;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Familia
        {
            get { return familia; }
            set { familia = value; }
        }
        
        public int PinKod
        {
            get { return pinkod; }
            set { pinkod = value; }
        }

        public int Balans
        {
            get { return balans; }
            set { balans = value; }
        }
        public Client()
        {
        }

    }
}

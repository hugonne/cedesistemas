using System;

namespace Cedesistema.NetCore.PruebasDeConcepto
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var hugo = new Adulto
            {
                Nombre = "Hugo Aristi",
                Edad = 41,
                Cedula = "123456"
            };

            var susana = new Ninno();
            susana.Nombre = "Susana Aristi";
            susana.Edad = 11;
            susana.DulceFavorito = "Turrón";
            susana.EsFeliz = false;

            //Object initializer
            var santi = new Ninno
            {
                Nombre = "Santiago Aristi",
                Edad = 6,
                EsFeliz = false
            };
            santi.CumplirAnnos();
            santi.CumplirAnnos(2);
            susana.CumplirAnnos(5);
        }
    }

    public class Animal
    {
        public int Patas { get; set; }
        protected int Color { get; set; }
    }

    public class Perro : Animal, ICapazDeEnvejecer, ICapazDeTrabajar
    {
        public int Edad { get; set; }
        private bool esCachorro = true;

        public void CumplirAnnos(int cuantos = 1)
        {
            Edad += cuantos * (esCachorro ? 5 : 7);
        }
    }

    public class Persona : ICapazDeEnvejecer
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool EsFeliz { get; set; }
        public Perro Mascota { get; set; }

        //Implementación 
        public void CumplirAnnos(int cuantos = 1)
        {
            //Cuerpo del método (lógica del comportamiento)
            Edad += cuantos;
            if (cuantos == 1)
            {
                EsFeliz = true;
            }
        }

        public void AdoptarMascota(Perro perro, int edad)
        {
            Mascota = perro;
            Mascota.Edad = edad;
        }
    }

    public class Adulto : Persona, ICapazDeTrabajar
    {
        public string Cedula { get; set; }
    }

    public class Ninno : Persona
    {
        public string DulceFavorito { get; set; }
    }

    public interface ICapazDeEnvejecer
    {
        //Declaración - Firma del método (definición del comportamiento)
        void CumplirAnnos(int cuantos = 1);
    }

    public interface ICapazDeTrabajar
    {
        //Declaración - Firma del método (definición del comportamiento)
        void CumplirAnnos(int cuantos = 1);
    }
}

using LibraryBusiness.Mapper;

using System;
using System.Collections.Generic;


namespace LibraryBusiness.Entity
{
    public class Rent
    {
        public int ID { get; set; }
        public int ID_knihy { get; set; }
        public int ID_zakaznika { get; set; }

        public Rent() { }

        public Rent(int id)
        {
            this.ID = id;
  
        }

        public  Rent(int id, int id_k, int id_z)
        {
            this.ID = id;
            this.ID_knihy = id_k;
            this.ID_zakaznika = id_z;
        }
       
        //public DateTime od_kedy { get; set; }
        //public DateTime do_kedy { get; set; }


        public static List<Rent> LoadAll()
        {
            List<Rent> rents = new List<Rent>();    

            List<Rental> rentals = XMLGateway.SelectAll();  

            foreach (Rental rental in rentals)
            {
                Rent r = new Rent(rental.id, rental.id_kniha, rental.id_zakaznik);
                rents.Add(r);
            }
            return rents;
        }

       /* public static List<Rent> LoadByLogin()
        {
            List<Rent> rents = new List<Rent>();

            List<Rental> rentals = XMLGateway.SelectLogin();

            foreach (Rental rental in rentals)
            {
                Rent r = new Rent(rental.id);
                rents.Add(r);
            }
            return rents;
        }*/

        public bool InsertData(Rent rent)
        {
            if (this.ID == -1)
            {
                Rental rental = new Rental();

                rental.id = this.ID;
                rental.id_kniha = this.ID_knihy;
                rental.id_zakaznik = this.ID_zakaznika;

                if (XMLGateway.Insert(rental))
                {
                    this.ID = rental.id;
                    return true;
                }
                return false;
            }
            else
            {
                Rental rental = new Rental();
                rental.id = this.ID;
                rental.id_kniha = this.ID_knihy;
                rental.id_zakaznik = this.ID_zakaznika;

                return XMLGateway.Insert(rental);

            }
        }


        public bool Load()
        {
            Rental guest = XMLGateway.Select(this.ID);

            if (guest.id != -1)
            {
                this.ID = guest.id;
                this.ID_knihy = guest.id_kniha;
                this.ID_zakaznika = guest.id_zakaznik;
             

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete()
        {
            return XMLGateway.Delete(this.ID);
        }





    }

}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryBusiness.Mapper
{
    public struct Rental
    {
        public int id;
        public int id_kniha;
        public int id_zakaznik;
        //public DateTime dateTime_od;
        //public DateTime dateTime_do;
    }


    public class XMLGateway
    {
        private static XmlDocument xmlDocument;
        private static string file = null;
        private static XmlDocument xmlDoc;
        private static int freeID = 0;
        public static void LoadDocument(string filePath)
        {
            file = filePath;
            xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(file);
            }
            catch (Exception)
            {
                xmlDoc = null;
                return;
            }

            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");

            freeID = Convert.ToInt32(freeIDNode.InnerText);

        }

        private static void SaveDocument()
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");
            freeIDNode.InnerText = freeID.ToString();

            xmlDoc.Save(file);
        }

        private static bool CheckDocument()
        {
            if (xmlDoc == null)
                return false;

            if (!File.Exists(file))
                return false;

            return true;
        }


        public static bool fileExists()
        {
            if (xmlDoc == null)
                return false;

            if (!File.Exists(file))
                return false;

            return true;
        }

        public static List<Rental> SelectAll()
        {
            List<Rental> rentals = new List<Rental>();
            if (!CheckDocument())
            {
                return rentals;
            }
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Rent");

            foreach (XmlNode guestNode in list)
            {
                Rental guest = new Rental();
                Fill(guestNode, ref guest);

                rentals.Add(guest);
            }
            return rentals;
        }


        public static Rental Select(int guestId)
        {
            Rental p = new Rental();

            if (!CheckDocument())
            {
                return p;
            }

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Rent");

            XmlNode guestNode = null;

            foreach (XmlNode guest in list)
            {
                XmlNodeList childs = guest.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID_knihy")
                    {
                        guestNode = (child.InnerText == guestId.ToString()) ? guest : null;
                        break;
                    }
                }

                if (guestNode != null)
                {
                    break;
                }
            }

            if (guestNode != null)
            {
                Fill(guestNode, ref p);
            }

            return p;
        }


       /* public static List<Rental> SelectLogin(int guestId)
        {
            List<Rental> rentals = new List<Rental>();
            if (!CheckDocument())
            {
                return rentals;
            }
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Rent");

            XmlNode guestNode = null;

            foreach (XmlNode guest in list)
            {
                XmlNodeList childs = guest.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID_zakaznika")
                    {
                        guestNode = (child.InnerText == guestId.ToString()) ? guest : null;
                        break;
                    }
                }

                if (guestNode != null)
                {
                    break;
                }
            }

            if (guestNode != null)
            {
                Fill(guestNode, ref rent);
            }

            return rentals;
        }*/




        public static void Fill(XmlNode guestNode, ref Rental guest)
        {
            foreach (XmlNode child in guestNode.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    guest.id = int.Parse(child.InnerText);
                }
                if (child.Name == "ID_knihy")
                {
                    guest.id_kniha = int.Parse(child.InnerText);
                }
                if (child.Name == "ID_zakaznika")
                {
                    guest.id_zakaznik = int.Parse(child.InnerText);
                }
            }
        }

        public static bool Insert(Rental rental)
        {
            if (!CheckDocument())
            {
                return false;
            }

            XmlElement root = xmlDoc.DocumentElement;
            XmlElement guest = xmlDoc.CreateElement("Rent");

            XmlElement id = xmlDoc.CreateElement("ID");
            id.InnerText = freeID.ToString();
            rental.id = freeID;
            freeID = freeID + 1;
            guest.AppendChild(id);

            XmlElement id_kniha = xmlDoc.CreateElement("ID_knihy");
            id_kniha.InnerText = rental.id_kniha.ToString();
            guest.AppendChild(id_kniha);

            XmlElement id_zakaznik = xmlDoc.CreateElement("ID_zakaznika");
            id_zakaznik.InnerText = rental.id_zakaznik.ToString();
            guest.AppendChild(id_zakaznik);


            root.AppendChild(guest);

            SaveDocument();

            return true;
        }

        public static int GetFreeNode() 
        {
         
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeNode = root.SelectSingleNode("freeID");

            return Convert.ToInt32(freeNode.InnerText);
        }


        public static bool Update(Rental Guest)
        {
            if (!CheckDocument())
            {
                return false;
            }

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Rent");

            XmlNode guestNode = null;

            foreach (XmlNode node in list)
            {
                XmlNodeList childs = node.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID" && child.InnerText == Guest.id.ToString())
                    {
                        guestNode = node;
                        break;
                    }
                }

                if (guestNode != null)
                    break;
            }

            foreach (XmlNode child in guestNode.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    child.InnerText = Guest.id.ToString();
                }
                if (child.Name == "ID_knihy")
                {
                    child.InnerText = Guest.id_kniha.ToString();
                }
                if (child.Name == "ID_zakaznika")
                {
                    child.InnerText = Guest.id_zakaznik.ToString();
                }
            }

            SaveDocument();
            return true;
        }


        public static bool Delete(int guestId)
        {
            if (!CheckDocument())
            {
                return false;
            }

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Rent");

            XmlNode guestNode = null;

            foreach (XmlNode node in list)
            {
                XmlNodeList childs = node.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID" && child.InnerText == guestId.ToString())
                    {
                        guestNode = node;
                        break;
                    }
                }

                if (guestNode != null)
                    break;
            }
            root.RemoveChild(guestNode);
            SaveDocument();

            return true;
        }


    }
}


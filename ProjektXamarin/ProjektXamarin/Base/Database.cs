using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace ProjektXamarin.Base
{
    public class Database
    {
        static readonly string dbpathOffer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaOffers.json");
        static readonly string dbpathCompany = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaCompanies.json");
        static readonly string dbpathUser = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaUsers.json");

        public List<Offer> GetOffers()
        {
            List<Offer> ret = new List<Offer>();

            try
            {
                string read = File.ReadAllText(dbpathOffer);
                ret = JsonConvert.DeserializeObject<List<Offer>>(read);
            }
            catch
            {
                ret = new List<Offer>();
                string read = JsonConvert.SerializeObject(ret);
                File.WriteAllText(dbpathOffer, read);
            }

            return ret;
        }
        public void AddOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            if (ret.Count > 0) { offer.Offer_id = ret[ret.Count - 1].Offer_id + 1; }
            else { offer.Offer_id = 0; }

            ret.Add(offer);

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public void UpdateOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Offer_id == offer.Offer_id)
                {
                    ret[i] = offer;
                }
            }

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public void DeleteOffer(Offer offer)
        {
            List<Offer> ret = GetOffers();

            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Offer_id == offer.Offer_id)
                {
                    ret.RemoveAt(i);
                }
            }

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathOffer, read);

        }
        public List<Company> GetCompanies()
        {
            List<Company> ret = new List<Company>();

            try
            {
                string read = File.ReadAllText(dbpathCompany);
                ret = JsonConvert.DeserializeObject<List<Company>>(read);
            }
            catch
            {
                ret = new List<Company>();
                string read = JsonConvert.SerializeObject(ret);
                File.WriteAllText(dbpathCompany, read);
            }

            return ret;
        }
        public void AddCompany(Company company)
        {
            List<Company> ret = GetCompanies();

            if (ret.Count > 0) { company.Company_id = ret[ret.Count - 1].Company_id + 1; }
            else { company.Company_id = 0; }

            ret.Add(company);

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathCompany, read);

        }
        public void EditCompany(Company company)
        {
            List<Company> ret = GetCompanies();

            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Company_id == company.Company_id)
                {
                    ret[i] = company;
                }
            }

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathCompany, read);

        }
        public List<User> GetUsers()
        {
            List<User> ret = new List<User>();

            try
            {
                string read = File.ReadAllText(dbpathUser);
                ret = JsonConvert.DeserializeObject<List<User>>(read);
            }
            catch
            {
                ret = new List<User>();
                string read = JsonConvert.SerializeObject(ret);
                File.WriteAllText(dbpathUser, read);
            }

            return ret;
        }
        public void AddUser(User user)
        {
            List<User> ret = GetUsers();

            if (ret.Count > 0) { user.User_id = ret[ret.Count - 1].User_id + 1; }
            else { user.User_id = 0; }

            ret.Add(user);

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathUser, read);

        }
        public void EditUser(User user)
        {
            List<User> ret = GetUsers();

            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].User_id == user.User_id)
                {
                    ret[i] = user;
                }
            }

            string read = JsonConvert.SerializeObject(ret);
            File.WriteAllText(dbpathUser, read);

        }
    }
}

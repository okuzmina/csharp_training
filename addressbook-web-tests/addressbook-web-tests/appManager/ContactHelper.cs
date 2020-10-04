using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper CreateContactWholeProcess(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactHelper EditContactWholeProcess(int index, ContactData contact)
        {
            EditContact(index);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count;
        }

        public ContactHelper RemoveContactWholeProcess(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    
                    IWebElement lastName = element.FindElement(By.XPath("./td[2]"));
                    IWebElement firstName = element.FindElement(By.XPath("./td[3]"));

                    contactCache.Add(new ContactData(firstName.Text, lastName.Text){
                        Id = element.FindElement(By.Name("selected[]")).GetAttribute("value")
                    });
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("mobile"), contact.MobilePhone);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value = 'Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@value = 'Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper CheckExistingCreateIfNot()
        {
            if (!IsContactExist())
            {
                ContactData contactNew = new ContactData("pre-created", "pre-created");
                CreateContactWholeProcess(contactNew);
            }
            return this;
        }
    }
}

﻿using OpenQA.Selenium;
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

        public ContactHelper EditContactWholeProcess(int index, ContactData contact)
        {
            EditContact(index);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveContactWholeProcess(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
            foreach (IWebElement element in elements)
            {
                IWebElement lastName = element.FindElement(By.XPath("./td[2]"));
                IWebElement firstName = element.FindElement(By.XPath("./td[3]"));
                contacts.Add(new ContactData(firstName.Text, lastName.Text));
            }
            return contacts;
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompaireGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = applicationManager.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();

                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}

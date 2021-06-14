using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
//using AtomicSeller.AccessRights;

namespace AtomicSeller.Helpers.Navigation
{
    public class NavigationHelper
    {
        // Singleton stuff
        public static NavigationHelper Instance;

        public static NavigationHelper Init(RouteData routeData, ITempDataDictionary tempData)
        {
            return Instance = new NavigationHelper(routeData, tempData);
        }

        // First-level menu items
        public List<MenuItem> MenuItems { get; private set; }
        // First-level footer menu items
        public List<MenuItem> FooterItems { get; private set; }
        private List<MenuItem> AllItems { get; set; }

        private readonly ITempDataDictionary tempData;
        private readonly string controller;
        private readonly string action;

        public enum MenuItemsEnum
        {
            Home,
            Orders,
            //Shipments,
            Shipping,
            Settings,
            CustomerAccount,
            Admin,
            StoresSettings,
            ShippingServicesSettings,
            UserPreferences,
            BackupRestore,
            ExportData,
            InvoicesSettings,
            BulkTools,
            ShipmentDisplay,
            ShipmentEdit,
            ClientsList,
            ClientSettings,
            ClientSuperSettings,
            UserSettings,
            UserClientSettings,
            EmailReportingSettings,
            UserProfile,
            Balances,
            Deposit,
            Withdraw,
            History,
            Tracking,
            Stock,
            Reporting,
            MerchantSettings,
            WarehouseSettings,
            AddressesSettings,
            LicencesSettings,
            WMS,
            ScheduleView
        }

        private NavigationHelper(RouteData routeData, ITempDataDictionary tempData)
        {
            this.tempData = tempData;
            buildLists();

            controller = routeData.Values["controller"].ToString();
            action = routeData.Values["action"].ToString();

            // Ensure that no MenuItem has both controller&action AND children
            if (AllItems.Any(item => (item.Controller != null || item.Action != null) && item.Children.Count > 0))
                throw new Exception("A MenuItem cannot have both action link and children.");

            // Determine active item
            var activeMenuItem = AllItems.FirstOrDefault(menuItem => menuItem.Controller == controller && menuItem.Action == action);
            if (activeMenuItem != null)
                activeMenuItem.IsActive = true;
        }

        private void buildLists()
        {
            MenuItems = new List<MenuItem>();
            FooterItems = new List<MenuItem>();
            AllItems = new List<MenuItem>();

            // Menu mes commandes
            //var MainMenuSection = MenuItem.NewSection(Local.TranslatedMessage("MITFAFShippingProcess"), Mdi.Store);
            var AdminMenuSection = MenuItem.NewSection("Admin", Mdi.Shuffle);

            AdminMenuSection.AddChildren(
                MenuItem.NewItem(MenuItemsEnum.Home, new Local().TranslatedMessage("MITFAFquickProcessToolStripMenuItem"), Mdi.Home, "Home", "Index")
            );

            var JobsMenuSection = MenuItem.NewSection("Jobs", Mdi.Shuffle);

            JobsMenuSection.AddChildren(
                MenuItem.NewItem(MenuItemsEnum.ScheduleView, "Jobs", Mdi.Login, "Jobs", "JobList"),
                MenuItem.NewItem(MenuItemsEnum.ScheduleView, "JobLogs", Mdi.Login, "Jobs", "JobLogList"),
                MenuItem.NewItem(MenuItemsEnum.ScheduleView, "Jobs Real Time", Mdi.Login, "Jobs", "Jobsrealtime")
            );

            MenuItems.Add(AdminMenuSection);
            MenuItems.Add(JobsMenuSection);

            // Build AllItems list
            AllItems.AddRange(MenuItems);
            foreach (var menuItem in MenuItems)
                AllItems.AddRange(menuItem.Children);
            AllItems.AddRange(FooterItems);

        }



        private MenuItem getActiveMenuItem(MenuItem item = null)
        {
            return (item != null ? item.Children : AllItems).FirstOrDefault(menuItem => menuItem.IsActive);
        }

        public List<MenuItem> GetBreadcrumb()
        {
            var list = new List<MenuItem>();

            MenuItem parent = null;
            MenuItem activeChild;

            while ((activeChild = getActiveMenuItem(parent)) != null)
            {
                list.Add(activeChild);
                parent = activeChild;
            }            
            return list;
        }

        public void SetActiveMenuItem(MenuItemsEnum item)
        {
            var menuItem = AllItems.FirstOrDefault(m => m.MenuItemEnum == item);

            if (menuItem == null)
            { /*               
                LogToView(
                //"Aucun MenuItem ne correspond à \"" +
                new Local().TranslatedMessage("MESNULNoMenuItemAccordingTo")+
                    item +
                //"\".\nUtilisez-vous un MenuItem de l'extranet salariés sur l'extranet adhérents ou vice-versa ?",
                new Local().TranslatedMessage("MESNULPLEASEUSECLIENTACCESSWEBSITE"),
                    FlashMessageType.Error);
                    */
                return;
            }

            var activeMenuItem = getActiveMenuItem();
            if (activeMenuItem != null)
            {
                /*
                LogToView(
                //"MenuItem actif auto-détecté (" +
                new Local().TranslatedMessage("MESNULACTIVEMENU") +
                    activeMenuItem.MenuItemEnum +
                //") manuellement re-défini (" +
                new Local().TranslatedMessage("MESNULREDEFINED") +
                    menuItem + 
                    "). " +
                //"Ceci est déconseillé car entraîne des dysfonctionnements du fil d'ariane."
                new Local().TranslatedMessage("MESNULPLEASEDONTUSE")
                    , FlashMessageType.Warning);
                    */
                activeMenuItem.IsActive = false;
            }

            menuItem.IsActive = true;
        }

        public void EnsureActiveItem()
        {
            /*
            if (getActiveMenuItem() == null)
                
                LogToView(
                //"Aucun MenuItem n'a explicitement été défini comme actif, impossible de trouver un candidat implicite pour le controller \"" +
                new Local().TranslatedMessage("MESNULNOEXPLICITMENUITEM")+
                    controller +
                //"\" et l'action \"" +
                new Local().TranslatedMessage("MESNULANDACTION") +
                    action + 
                    "\"", 
                    FlashMessageType.Error);
                    */
        }

        private void LogToView(string message, FlashMessageType type)
        {
           FlashMessage.Flash(tempData, new FlashMessage(message, type, "NavigationHelper", true));
        }
    }
}

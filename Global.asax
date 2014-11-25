<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        page page = new global::page();
        List<page> pages = page.getPages();
        RegisterRoutes(RouteTable.Routes, pages);
    }

    public static void RegisterRoutes(RouteCollection routes, List<page> pages)
    {
        routes.MapPageRoute("hjem", "hjem", "~/default.aspx", false);
        routes.MapPageRoute("nyheder", "nyheder", "~/nyheder.aspx", false);

        foreach (page page in pages)
        {
            routes.MapPageRoute(page._name, Regex.Replace(page._name, @"\s", "-"), "~/" + Regex.Replace(page._name, @"\s", "-") + ".aspx", false);

            int i = 0;
            foreach (subpage subpage in page._subpages)
            {
                routes.MapPageRoute(subpage._name, Regex.Replace(page._name, @"\s", "-") + "/" + Regex.Replace(subpage._name, @"\s", "-"), "~/" + Regex.Replace(page._name, @"\s", "-") + ".aspx", false);
                i++;
            }
        }
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("hjem", "hjem", "~/default.aspx", false);
        routes.MapPageRoute("om os", "om-os", "~/om-os.aspx", false);
        routes.MapPageRoute("kategorier", "kategorier", "~/kategorier.aspx", false);
        routes.MapPageRoute("produkter", "produkter", "~/produkter.aspx", false);
        routes.MapPageRoute("support", "support", "~/support.aspx", false);
        routes.MapPageRoute("partnere", "partnere", "~/partnere.aspx", false);
        routes.MapPageRoute("dokumenter", "dokumenter", "~/dokumenter.aspx", false);
        routes.MapPageRoute("nyheder & begivenheder", "nyheder", "~/nyheder.aspx", false);    
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

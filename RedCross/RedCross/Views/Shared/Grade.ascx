<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RedCross.Models.Entities.Container.Container_List_Status>" %>

<li>
    <label for="grdID">年级</label><select id="grdID" name="grdID" >
    <option></option>
    <%for (int i = 0; i < Model.list_Grd.Count; ++i)
      { %>
      <option value="<%=Model.list_Grd[i].ID %>" 
      <%if(Model.user !=null && Model.user.Grd !=null && Model.user.Grd.ID == Model.list_Grd[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Grd[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="grdIDErr" style="display:none" class="Err"></div>
</li>
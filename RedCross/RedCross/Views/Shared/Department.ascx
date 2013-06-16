<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RedCross.Models.Entities.Container.Container_List_Status>" %>

<li>
    <label for="depID">部门</label><select id="depID" name="depID">
    <option></option>
    <%for (int i = 0; i < Model.list_Dep.Count; ++i)
      { %>
      <option value="<%=Model.list_Dep[i].ID %>"
      <%if(Model.user !=null && Model.user.Dep !=null && Model.user.Dep.ID == Model.list_Dep[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Dep[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="depIDErr" style="display:none" class="Err"></div>
</li>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RedCross.Models.Entities.Container.Container_List_Status>" %>

<li>
    <label for="clgId">学院</label><select id="clgId" name="clgId">
    <option></option>
    <%for (int i = 0; i < Model.list_Col.Count; ++i)
      { %>
      <option value="<%=Model.list_Col[i].ID %>"
      <%if(Model.user !=null && Model.user.Clg !=null && Model.user.Clg.ID == Model.list_Col[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Col[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="collageIDErr" style="display:none" class="Err"></div>
</li>


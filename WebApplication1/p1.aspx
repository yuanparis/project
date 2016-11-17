<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p1.aspx.cs" Inherits="WebApplication1.p1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        //使用AJAX代理解决AJAX跨域问题
        // 可取相对地址与绝对地址（webService所在的地址）
        var request = new XMLHttpRequest();
        var url = "p2.aspx";
        request.open("POST", url, false);
        request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        //request.setRequestHeader("Content-Length", 2); // 2即为参数的个数  
        request.onreadystatechange = updatePage;
        var strName = "13111111112";
        var strPwd = "test2";
        request.send("contact_person_mobile=" + strName + "&contact_person=" + strPwd); //发送参数的数据，可自行组合  

        function updatePage() {
            if (request.readyState == 4 && (request.status == 200 || request.status == 304)) {  // 304未修改
                var text = request.responseText;

                console.log(text);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

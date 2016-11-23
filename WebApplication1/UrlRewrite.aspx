<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlRewrite.aspx.cs" Inherits="WebApplication1.UrlRewrite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    伪静态：Url Rewrite<br />
        动态读取参数：<%=StrUrl %><br />
1.1伪静态介绍、作用<br />

1.1.1为什么要伪静态<br />

在搜索引擎优化领域，静态页面的权重是大于动态页面的权重的。例如index.aspx会大于index.aspx?id=1的权重。通常情况下，动态页面中？后面的参数是读取数据库内容显示在前台页面上的。
        <br />
很显然如果id不同所展现的数据也是不同的。但搜索引擎会把所有的页面例如：index.aspx?id=1、index.aspx?id=2等所有的动态页面，认定为同一个页面index.aspx。为了增强搜索引擎的友好度，提高收录，我们需要实现把动态内容静态化。
<br />
1.1.2实现网页静态化
        <br />
我们很明显可以实现读取数据库内容根据模版生成对应id的静态页面。但是像淘宝京东等数以万计的商品之下，所占用的存储是海量的，需要大量的硬盘存储来存储这些静态网页。这是很理想的状况，但是现实是无法做得到的。
        <br />
所以伪静态闪亮登场~~~
        <br />
1.1.3什么是伪静态？
        <br />
伪静态就是我们把以前的动态参数放入url中通过后台逻辑，显示对应的数据。说白了就是，把我们以前的index.aspx?id=1的地址改为index-1.aspx页面（具体的伪静态的规则自己可以随便写的，在这里只是举例子），把动态参数去掉。我们在后台写相应的代码实现读取数据显示。
    </div>
    </form>
</body>
</html>

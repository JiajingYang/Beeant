﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invalidate.aspx.cs" Inherits="Beeant.Presentation.Admin.Home.Errors.Invalidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>亲您没有权限访问哦</title>
<style type="text/css">

body { font-family:Microsoft YaHei, Arial, SimHei, Simsun; color:#666d75; background:#FFF }
img { border:none}

/* clear float */
.cf { zoom:1} /* for IE */
.cf:after { content:"."; display: block; clear:both; font-size:0; height:0; visibility:hidden; overflow:hidden} /* for other */
/* end of clear float */

.main { width:800px; padding:0; margin:200px auto }
.main img { float:left; margin:0 0 0 150px }

.txt { float:left; width:450px; padding:0 0 0 20px }
.txt h1 { font-size:48px; line-height:48px }
.txt h2 { font-size:30px; line-height:30px}

</style>

</head>

<body>

    <div class="main cf">
    	<img src="/Images/404_bq.jpg" width="180" height="160" alt="" />
    	<div class="txt">
        	<h1>对不起！</h1>
        	<h2><%=Title %></h2>
        </div>
    </div>


</body>
</html>

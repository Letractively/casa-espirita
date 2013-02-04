<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><div id="content">
    
        		<div class="container med left" id="graphs">
                	<div class="conthead">
                		<h2>Tabelas de Vendas</h2>

                    </div>
                 
                	<div class="contentbox">
                    	<ul class="tablinks tabfade">
                        	<li class="nomar"><a href="#graphs-1">Barra</a></li>
                            <li><a href="#graphs-2">Torta</a></li>
                            <li><a href="#graphs-3">Linha</a></li>
                            <li><a href="#graphs-4">Área</a></li>

                        </ul>


                    	<div class="tabcontent" id="graphs-1">
                            <table style="display: none; height: 250px" class="bar" width="52%">
                                <caption> Membros Registados</caption>
                                <thead>
                                    <tr>
                                        <td></td>

                                        <th scope="col">Jan</th>
                                        <th scope="col">Fev</th>
                                        <th scope="col">Mar</th>
                                        <th scope="col">Abr</th>
                                        <th scope="col">Mai</th>
                                        <th scope="col">Jun</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">2011</th>
                                        <td>190</td>
                                        <td>160</td>

                                        <td>40</td>
                                        <td>120</td>
                                        <td>30</td>
                                        <td>70</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">2010</th>

                                        <td>3</td>
                                        <td>40</td>
                                        <td>30</td>
                                        <td>45</td>
                                        <td>35</td>
                                        <td>49</td>

                                    </tr>	
                                </tbody>
                            </table>
                    </div>
                    <div class="tabcontent" id="graphs-2">
                        <table style="display: none; height: 250px" class="pie" width="52%">
                            <caption> Membros Registados</caption>
                                <thead>

                                    <tr>
                                        <td></td>
                                        <th scope="col">Jan</th>
                                        <th scope="col">Fev</th>
                                        <th scope="col">Mar</th>
                                        <th scope="col">Abr</th>
                                        <th scope="col">Mai</th>
                                        <th scope="col">Jun</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">2011</th>
                                        <td>190</td>

                                        <td>160</td>
                                        <td>40</td>
                                        <td>120</td>
                                        <td>30</td>
                                        <td>70</td>
                                    </tr>

                                    <tr>
                                        <th scope="row">2010</th>
                                        <td>3</td>
                                        <td>40</td>
                                        <td>30</td>
                                        <td>45</td>

                                        <td>35</td>
                                        <td>49</td>
                                    </tr>	
                                </tbody>
                            </table>
                    </div>
                    <div class="tabcontent" id="graphs-3">
                            <table style="display: none; height: 250px" class="line" width="52%">

                                <caption> Membros Registados</caption>
                                <thead>
                                    <tr>
                                        <td></td>
                                        <th scope="col">Jan</th>
                                        <th scope="col">Fev</th>
                                        <th scope="col">Mar</th>
                                        <th scope="col">Abr</th>
                                        <th scope="col">Mai</th>
                                        <th scope="col">Jun</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>

                                        <th scope="row">2011</th>
                                        <td>190</td>
                                        <td>160</td>
                                        <td>40</td>
                                        <td>120</td>
                                        <td>30</td>

                                        <td>70</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">2010</th>
                                        <td>3</td>
                                        <td>40</td>
                                        <td>30</td>

                                        <td>45</td>
                                        <td>35</td>
                                        <td>49</td>
                                    </tr>	
                                </tbody>
                            </table>
                    	</div>
                   		<div class="tabcontent" id="graphs-4">

                            <table style="display: none; height: 250px" class="area" width="52%">
                               <caption> Membros Registados</caption>
                                <thead>
                                    <tr>
                                        <td></td>
                                        <th scope="col">Jan</th>
                                        <th scope="col">Fev</th>
                                        <th scope="col">Mar</th>
                                        <th scope="col">Abr</th>
                                        <th scope="col">Mai</th>
                                        <th scope="col">Jun</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr>
                                        <th scope="row">2011</th>
                                        <td>190</td>
                                        <td>160</td>
                                        <td>40</td>
                                        <td>120</td>

                                        <td>30</td>
                                        <td>70</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">2010</th>
                                        <td>3</td>
                                        <td>40</td>

                                        <td>30</td>
                                        <td>45</td>
                                        <td>35</td>
                                        <td>49</td>
                                    </tr>	
                                </tbody>
                            </table>

                   		</div>

                      
                    </div>
                </div>
                
              
                <div class="container sml right">
                	<div class="conthead">
                		<h2>Estatos</h2>
                    </div>
                	<div class="contentbox">
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>                    	
                    </div>
                </div>

               
                <div style="clear: both"></div>
        	</div>
</asp:Content>
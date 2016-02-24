function myFunction2(aData) {
    debugger;

    for (var i = mainData.length - 1; i >= 0; i--) {
        if (mainData[i].Id == aData) {
            mainData.splice(i, 1);
        }
    }

    //var idx = mainData.indexOf(aData);
    //mainData.splice(idx);

    var tr;
    $("#tbodyid").empty();
    for (var i = 0; i < mainData.length; i++) {
        tr = $('<tr/>');
        tr.append("<td>" + (i + 1) + ".</td>");
        tr.append("<td>" + mainData[i].Id + "</td>");
        tr.append("<td>" + mainData[i].productCode + "</td>");
        tr.append("<td>" + mainData[i].ProductName + "</td>");
        tr.append("<td>" + mainData[i].SellPrice + "</td>");
        tr.append("<td>" + mainData[i].productQuantity + "</td>");
        tr.append("<td>" + mainData[i].totalForthisProduct + "</td>");
        tr.append("<td>" + "<button type='button' id='btn' class='btn btn-danger' onClick='myFunction2(" + mainData[i].productCode + ");' >" + "Remove" + "</button>" + "</td>");
        $('table').append(tr);
    }
    calculateSidebar();
}

function calculateSidebar() {
    var total = 0;
    for (var i = 0; i < mainData.length; i++) {

        total += parseFloat(mainData[i].SellPrice * mainData[i].productQuantity);
    }
    $('#totalPrice').val(total);

    $('#grandTotal').val(total);
}

var mainData = [];
$(document).ready(function () {

    $('#totalPrice').val(0);
    $('#tax').val(0);
    $('#discount').val(0);
    $('#adjustment').val(0);
    $('#grandTotal').val(0);

    //$(document).ready(function () {
    // var json = [{ "User_Name": "John Doe", "score": "10", "team": "1" }, { "User_Name": "Jane Smith", "score": "15", "team": "2" }, { "User_Name": "Chuck Berry", "score": "12", "team": "2" }];
    var tr;
    for (var i = 0; i < mainData.length; i++) {
        tr = $('<tr/>');
        tr.append("<td>" + mainData[i].productCode + "</td>");
        tr.append("<td>" + mainData[i].ProductName + "</td>");
        tr.append("<td>" + mainData[i].SellPrice + "</td>");
        $('table').append(tr);
    }
    //});
    function mySpliceFunction(aData) {
        debugger;
        mainData.splice(aData);
        myFunction();
    }

    $('#sellSubmit').click(function (e) {
        debugger;
        var productObj = mainData;

        var order = {

            Inv_CustomerId: 1,
            OrderDate: new Date(),
            OrderDetails: "aaa",
            TotalUnit: 0,
            TotalPrice: $('#totalPrice').val(),
            Paid: $('#totalPrice').val(),
            Due: 0,
            DiscountPercent: 0,
            DiscountAmount: $('#discount').val(),
            Adjustment: $('#adjustment').val(),
            Note: "good",
            CreatedDate: new Date(),
            UpdateDate: new Date(),
            IsActive: 1,
            IsDeleted: 0,
            CompanyId: 123,
            UserId: 123,
            OrderProducts: productObj
        }

        $.ajax({

            url: "/SaleMain/SellProduct",
            type: "POST",
            data: JSON.stringify({ 'aProduct': order }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger;
               


                //$('#Id').val(data.Inv_ProductId);

                //$('#loadProductCode').val(data.ProductCode);
                //$('#loadProductDetails').val(data.ProductDetails);

                //$('#loadProductName').val(data.ProductName);
                //$('#loadSellPrice').val(data.SellPrice);
                //$('#loadTax').val(data.Tax);
                //$('#productQuantity').val(1);
                //$('#totalForthisProduct').val(data.SellPrice);

                //$('#myModal').modal('show');
                
            },

            error: function () {
                debugger;
                alert("An error has occured!!!");
            }

        });

    });

    function myFunction() {
        // alert('hi');
        var tr;
        $("#tbodyid").empty();
        for (var i = 0; i < mainData.length; i++) {
            tr = $('<tr/>');
            tr.append("<td>" + (i + 1) + ".</td>");
            tr.append("<td>" + mainData[i].Id + "</td>");
            tr.append("<td>" + mainData[i].productCode + "</td>");
            tr.append("<td>" + mainData[i].ProductName + "</td>");
            tr.append("<td>" + mainData[i].SellPrice + "</td>");
            tr.append("<td>" + mainData[i].productQuantity + "</td>");
            tr.append("<td>" + mainData[i].totalForthisProduct + "</td>");
            tr.append("<td>" + "<button type='button' id='btn' class='btn btn-danger' onClick='myFunction2(" + mainData[i].productCode + ");' >" + "Remove" + "</button>" + "</td>");
            $('table').append(tr);
        }
    }



    //$('#sellSubmit').click(function (e) {
    //        debugger;
    //        var productObj = mainData
    //    });



    function recalOnChangeOfQuantity() {
        var newQuantity = $('#productQuantity').val();
        var sellPrice = $('#loadSellPrice').val();
        $('#totalForthisProduct').val(newQuantity * sellPrice);

    }

    $('#productQuantity').keyup(function (e) {
        debugger;
        var newQuantity = $('#productQuantity').val();
        if (newQuantity == "") {
            newQuantity = 0;
        }

        var sellPrice = $('#loadSellPrice').val();
        $('#totalForthisProduct').val(newQuantity * sellPrice);
    });

    $('#addToCart').click(function (e) {
        debugger;
        var id = $('#Id').val();
        var loadProductCode = $('#loadProductCode').val();
        var loadProductDetails = $('#loadProductDetails').val();

        var loadProductName = $('#loadProductName').val();
        var loadSellPrice = $('#loadSellPrice').val();
        var loadTax = $('#loadTax').val();
        var loadproductQuantity = $('#productQuantity').val();
        var loadtotalForthisProduct = $('#totalForthisProduct').val();
        debugger;
        var aData = {
            Id: id,
            productCode: loadProductCode,
            ProductDetails: loadProductDetails,
            ProductName: loadProductName,
            SellPrice: loadSellPrice,
            loadTax: loadTax,
            productQuantity: loadproductQuantity,
            totalForthisProduct: loadtotalForthisProduct,
            Inv_ProductId:id,
        OrderQuantity:loadproductQuantity
        }

        mainData.push(aData);
        calculateSidebar();
        myFunction();
    });

    $('#dSubmit').click(function (e) {
        debugger;
        var id = $('#data').val();

        data: JSON.stringify({ 'Options': id }),
        e.preventDefault(); // <------------------ stop default behaviour of button
        var element = this;
        $.ajax({

            url: "/Product/search",
            type: "POST",
            data: JSON.stringify({ 'id': id }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger;
                //$('#loadProductCode').attr("data-myval", data.ProductCode);
                //$('#loadProductDetails').attr("data-myval", data.ProductDetails);
                //$('#loadProductName').attr("data-myval", data.ProductName);
                //$('#loadProductCode').val(data.ProductCode);

                // loadProductCode.dataset.myval = data.ProductCode;


                $('#Id').val(data.Inv_ProductId);

                $('#loadProductCode').val(data.ProductCode);
                $('#loadProductDetails').val(data.ProductDetails);

                $('#loadProductName').val(data.ProductName);
                $('#loadSellPrice').val(data.SellPrice);
                $('#loadTax').val(data.Tax);
                $('#productQuantity').val(1);
                $('#totalForthisProduct').val(data.SellPrice);

                $('#myModal').modal('show');
                //if (data.status == "Success") {
                //    $('#myModal').modal('show');
                //  //  modelData
                //   // alert(data.data);
                //    $(element).closest("form").submit(); //<------------ submit form
                //} else {
                //    alert("Error occurs on the Database level!");
                //}
            },

            error: function () {
                debugger;
                alert("An error has occured!!!");
            }

        });

    });
});
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:inventory_management_software/models/Import.dart';
import 'package:inventory_management_software/models/ImportDetail.dart';
import 'package:inventory_management_software/models/Product.dart';
import 'package:inventory_management_software/services/APIService.dart';


class ImportDetailProduct extends StatefulWidget {
  final int importId;
  ImportDetail? importDetail;
  //DateTime? date;

  ImportDetailProduct(this.importId, this.importDetail);

  @override
  _ImportDetailProductState createState() => _ImportDetailProductState();
}

class _ImportDetailProductState extends State<ImportDetailProduct>{
  List<DropdownMenuItem> items = [];
  Product? _selectedProduct;
  int? productId;
  double discount = 0;
  int quantity = 1;
  final _formKey = GlobalKey<FormState>();
  @override
  void initState() {
    super.initState();
    if(widget.importDetail != null){
      discount = widget.importDetail!.discount!;
      quantity = widget.importDetail!.quantity!;
      productId = widget.importDetail!.productId;
    }
  }

  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Import details'),
          actions: [
            RaisedButton(
              onPressed: (){
                if(_formKey.currentState!.validate()) {
                  if (productId == null)
                    showAlertDialog(context, 'Product is not selected.');
                  else {
                    var importDetail = Save();
                    if (widget.importDetail != null)
                      showAlertDialog(
                          context, 'Import detail was successfully saved.');
                    else
                      showAlertDialog(context, 'Product successfully added.');
                  }
                }
              },
              child: Text('Save', style: TextStyle(fontSize: 18),),
              color: Colors.blue,
              textColor: Colors.white,
              elevation: 5,
            )
          ],
        ),
        body: importDetailsWdget(context),
    );
  }

  showAlertDialog(BuildContext context, String message) {
    // Create button
    Widget okButton = FlatButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.of(context).pop();
      },
    );

    // Create AlertDialog
    AlertDialog alert = AlertDialog(
      title: Text("Saved!"),
      content: Text(message),
      actions: [
        okButton,
      ],
    );

    // show the dialog
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }

  Widget importDetailsWdget(BuildContext context) {
    return FutureBuilder<List<Product>>(
      future: GetProducts(_selectedProduct),
      builder: (BuildContext context, AsyncSnapshot<List<Product>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(
            child: Text('Loading...'),
          );
        }
        if (snapshot.hasError) {
          return Center(
              child: Text('${snapshot.error}')
          );
        }
        return Center(
          child: Form(
            key: _formKey,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                Container(
                  padding: EdgeInsets.all(16),
                  child: DropdownButtonFormField<dynamic>(
                    hint: widget.importDetail != null ? Text(widget.importDetail!.productName.toString())
                        : Text('Select a product'),
                    value: _selectedProduct,
                    isExpanded: true,
                    validator: (value){
                      if(productId == null)
                        return 'Product is a required field';
                      return null;
                    },
                    items: items,
                    onChanged: (newVal) {
                      _selectedProduct = newVal;
                      productId = _selectedProduct!.id;
                    },
                  ),
                ),
                Container(
                  padding: EdgeInsets.all(16),
                  child: TextFormField(
                    validator: (value){
                      if(value == null || value.isEmpty)
                        return 'Quantity is a required field';
                      if(int.parse(value) < 1)
                        return 'Quantity cannot be less then 1.';
                      return null;
                    },
                    textAlign: TextAlign.center,
                    keyboardType: TextInputType.number,
                    onFieldSubmitted: (newVal){
                      quantity = int.parse(newVal);
                    },
                    //controller: _dateController,
                    initialValue: quantity.toString(),
                    decoration: InputDecoration(
                        labelText: 'Quantity',
                        labelStyle: TextStyle(fontSize: 20)
                    )
                    ,
                  ),
                ),
                Container(
                  padding: EdgeInsets.all(16),
                  child: TextFormField(
                    textAlign: TextAlign.center,
                    validator: (value){
                      if(value == null || value.isEmpty)
                        return 'Discount is a required field';
                      if(double.parse(value) < 0 || double.parse(value) > 1)
                        return 'Discount must be between 0 and 1';
                      return null;
                    },
                    keyboardType: TextInputType.number,
                    onFieldSubmitted: (newVal){
                      discount = double.parse(newVal);
                    },
                    //controller: _dateController,
                    initialValue: discount.toString(),
                    decoration: InputDecoration(
                        labelText: 'Discount (0-1)',
                        labelStyle: TextStyle(fontSize: 20)
                    )
                    ,
                  ),
                )
              ],
            ),
          ),
        );
      },
    );
  }

  Future<List<Product>> GetProducts(Product? selectedItem) async{
    var products = await APIService.Get('Product', null);
    var productsList = products!.map((e) => Product.fromJson(e)).toList();

    items = productsList.map((item){
      return DropdownMenuItem<Product>(
          child: Text(item.name.toString()),
          value: item
      );
    }).toList();

    if(selectedItem != null && selectedItem.id != 0){
      _selectedProduct = productsList.where((element) => element.id == selectedItem.id).first;
      productId = _selectedProduct!.id;
    }

    return productsList;
  }


  Future<void> Save() async{
    if(widget.importDetail != null) {
      String bodyText = '{"productId": ${productId.toString()},'
          '"quantity": ${quantity.toString()},'
          '"discount": ${discount.toString()}}';
      print(bodyText + ' - ' + widget.importDetail!.id.toString());
      var import = await APIService.Put(
          'ImportDetail', widget.importDetail!.id, bodyText);
    }
    else{
      String query = 'ImportId=' + widget.importId.toString()
          + '&ProductId=' + productId.toString()
          + '&Quantity=' + quantity.toString()
          + '&Discount=' + discount.toString();
      print(query);
      var post = await APIService.Post('ImportDetail', query);
    }
  }

}

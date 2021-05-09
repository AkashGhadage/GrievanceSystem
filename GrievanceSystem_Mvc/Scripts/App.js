﻿$(document).ready(function () {

	var elem = '<div><p mb-0>Welcome to<br/><b>Online Grievance Portal</b></p></div>' +
		'<div class=""><a href="#login" class="btn btn-primary m-2">LOGIN</a> <br/>< a href = "#register" class="btn btn-warning  m-2" > REGISTER</a ></div > '

	$('[data-toggle="popover"]').popover({ animation: true, content: elem, html: true });


	//Show hide password functionality
	var showElement = $("#ShowHideLink");
	showElement.css("cursor", "pointer");

	showElement.click(function () {
		var Text = showElement.text(); //get
		if (Text == "Show") {
			$("#Password").attr("type", "Text");
			showElement.text("Hide"); //set
		}
		else {
			$("#Password").attr("type", "password");
			showElement.text("Show");
		}
	});

	var ddc = $("#dd_Category");
	var ddsc = $("#dd_Subcat");

	ddc.change(function () {
		var cId = $(this).val();
		$.getJSON("/Grievance/GetSubcategories", { categoryId: cId },
			function (classesData) {
				var select = $("#ddState");
				ddsc.empty();
				ddsc.append($('<option/>', {
					value: 0,
					text: "--Select Subcategory--"
				}));
				$.each(classesData, function (index, itemData) {
					ddsc.append($('<option/>', {
						value: itemData.Value,
						text: itemData.Text
					}));
				});
			}
		);
	});








	//Login validation part

	// Elements
	var email_Element = $("#EmailAddress");
	var Password_Element = $("#Password");
	var FormElement = $("#LoginForm");
	//flags
	var Email_Flag = false;
	var Password_Flag = false;

	//registration email checking 

	email_Element.blur(function (e) {
		$.ajax({
			type: "GET",
			url: "/api/account?email=" + email_Element.val(),
			success: function (response) {
				if (response == "Found") {
					//email already exists

					$("#EmailValidation").text("* Email Already Registered");
					email_Element.addClass("border border-danger");
					email_Element.focus();
				}
				else {
					$("#EmailValidation").text("");
					email_Element.removeClass("border border-danger");

				}
			}
		});
	});


	//Events
	// we call function that do validation and set value to flag element
	//email_Element.keyup(function () {
	//	Validate_Email();
	//});

	//Password_Element.keyup(function () {
	//	Validate_Password();

	//});

	//// validation Functions
	//function Validate_Email() {
	//	var Email = email_Element.val();
	//	var EmailPattern = new RegExp(/^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/);
	//	var cache = EmailPattern.test(Email);

	//	//var EmailPattern = new RegExp(/^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@(?:\S{1,63})$/); //valid 
	//	//var cache = EmailPattern.test(Email);


	//	if (Email == "" || Email == undefined) {
	//		$("#EmailValidation").text("* Email Field is required");
	//		email_Element.addClass("border border-danger");
	//		email_Element.focus();

	//	}
	//	else if (!EmailPattern.test(Email)) {
	//		$("#EmailValidation").text("* Please Enter valid Email Address");
	//		email_Element.addClass("border border-danger");

	//	}
	//	else {
	//		$("#EmailValidation").text(" ");
	//		email_Element.removeClass("border border-danger")
	//		Email_Flag = true;
	//	}
	//}

	//function Validate_Password() {
	//	var Password = Password_Element.val();
	//	//var PasswordPattern = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/); // /^((\+)?(\d{2}[-]))?(\d{10}){1}?$/

	//	if (Password == "" || Password == undefined) {
	//		$("#PasswordValidation").text("* Password Field is required");
	//		Password_Element.addClass("border border-danger");
	//		Password_Element.focus();
	//	}
	//	//else if (!PasswordPattern.test(Password)) {
	//	//	$("#PasswordValidation").text("* Please Enter valid Password");
	//	//	Password_Element.addClass("border border-danger");

	//	//}
	//	else {
	//		$("#PasswordValidation").text(" ");
	//		Password_Element.removeClass("border border-danger")
	//		Password_Flag = true;
	//	}
	//}
	////form submit event
	//FormElement.submit(
	//	function () {
	//		Email_Flag = Password_Flag = false;


	//		Validate_Password();
	//		Validate_Email();

	//		if (Email_Flag == true && Password_Flag == true) {
	//			return true;
	//		}
	//		else {
	//			return false;
	//		}
	//	}
	//);

	//heighlight the current active link
	$('li.active').removeClass('active');
	$('a[href="' + location.pathname + '"]').closest('li').addClass('active');

	//toogle sidebar 
	$("#menu-toggle").click(function (e) {
		e.preventDefault();
		$("#wrapper").toggleClass("toggled");
		var iconElement = $("#toggle-icon");
		if (iconElement.hasClass("fa-bars")) {

			iconElement.removeClass("fa-bars");

			iconElement.addClass("fa-times");
		}
		else if (iconElement.hasClass("fa-times")) {

			iconElement.removeClass("fa-times");

			iconElement.addClass("fa-bars");
		}
	});


	var oTable = $('#CellMemberTable').DataTable(
		{
			"ajax":
			{
				"url": "/Users/GetCellMember",
				"type": "GET",
				"dataType": "json"
			},
			"columns":
				[
					{
						"mData": null,
						"mRender": function (data, type, full) {
							return full['FirstName'] + ' ' + full['MiddleName'] + ' ' + full['LastName'];

						}
					},

					{ "data": "MobileNumber" },

					{
						"data": "DateCreated",
						"render": function (jsonDate) {
							if (jsonDate == "/Date(-62135596800000)/") {
								return "N/A";
							}
							else {
								var date = new Date(parseInt(jsonDate.substr(6)));
								var month = date.getMonth() + 1;
								return date.getDate() + "/" + month + "/" + date.getFullYear();
							}

						}
					},

					{
						"data": "DateModified",
						"render": function (jsonDate) {
							if (jsonDate == "/Date(-62135596800000)/") {
								return "N/A";
							}
							else {
								var date = new Date(parseInt(jsonDate.substr(6)));
								var month = date.getMonth() + 1;
								return date.getDate() + "/" + month + "/" + date.getFullYear();
							}
						}
					},

					{ "data": "EmailAddress" },
					{ "data": "Role" },
					{
						"title": "Actions",
						"data": "UserId",
						"searchable": false,
						"sortable": false,
						"render": function (data, type, full, meta) {
							return '<a href="/Users/Edit?id=' + data + '" class="btn btn-info my-2 mr-1 popup"  title="Edit cell member"><i class="fas fa-user-edit mr-1"></i>Edit</a>' +
								'<a href="/Users/ChangePassword?id=' + data + '" class="btn btn-warning my-2 mr-1 popup"  title="Edit Password"><i class="fas fa-user-edit mr-1"></i>Edit Password</a>' +
								'<a href="/Users/Delete/' + data + '" class="btn btn-danger my-2 ml-1 popup"  title="Delete cell member"><i class="far fa-trash-alt mr-1"></i>Delete</a>';
						}

					}
				],
			"language":
			{
				"emptyTable": "No data found , please click on <b>Add New</b> Button to Register Cell Members"

			}

		}
	);

	var sTable = $('#StudentTable').DataTable(
		{
			"ajax":
			{
				"url": "/Users/GetStudents",
				"type": "GET",
				"dataType": "json"
			},
			"columns":
				[
					{
						"mData": null,
						"mRender": function (data, type, full) {
							return full['FirstName'] + ' ' + full['MiddleName'] + ' ' + full['LastName'];

						}
					},

					{ "data": "MobileNumber" },

					{
						"data": "DateCreated",
						"render": function (jsonDate) {
							if (jsonDate == "/Date(-62135596800000)/") {
								return "N/A";
							}
							else {
								var date = new Date(parseInt(jsonDate.substr(6)));
								var month = date.getMonth() + 1;
								return date.getDate() + "/" + month + "/" + date.getFullYear();
							}

						}
					},

					{
						"data": "DateModified",
						"render": function (jsonDate) {
							if (jsonDate == "/Date(-62135596800000)/") {
								return "N/A";
							}
							else {
								var date = new Date(parseInt(jsonDate.substr(6)));
								var month = date.getMonth() + 1;
								return date.getDate() + "/" + month + "/" + date.getFullYear();
							}
						}
					},

					{ "data": "EmailAddress" },
					{ "data": "Role" },
					{
						"title": "Actions",
						"data": "UserId",
						"searchable": false,
						"sortable": false,
						"render": function (data, type, full, meta) {
							return '<a href="/Users/Edit?id=' + data + '" class="btn btn-info my-2 mr-1 studentpopup"  title="Edit Student"><i class="fas fa-user-edit mr-1"></i>Edit</a>' +
								'<a href="/Users/ChangePassword?id=' + data + '" class="btn btn-dark my-2 mr-1 studentpopup"  title="Edit Password"><i class="fas fa-user-edit mr-1"></i>Edit Password</a>' +
								'<a href="/Users/Delete/' + data + '" class="btn btn-danger my-2 ml-1 studentpopup"  title="Delete Student"><i class="far fa-trash-alt mr-1"></i>Delete</a>';
						}

					}
				],
			"language":
			{
				"emptyTable": "No data found , please click on <b>Add New</b> Button to Register Cell Members"

			}

		}
	);

	var cTable = $('#CategoryTable').DataTable(
		{
			"ajax":
			{
				"url": "/Category/GetCategories",
				"type": "GET",
				"dataType": "json"
			},
			"columns":
				[
					{ "data": "CategoryName" },
					{
						"title": "Actions",
						"data": "CategoryID",
						"searchable": false,
						"sortable": false,
						"render": function (data, type, full, meta) {
							return '<a href="/Category/Edit?id=' + data + '" class="btn btn-info my-2 mr-1 categorypopup"  title="Edit Category"><i class="fas fa-user-edit mr-1"></i>Edit</a>' +
								'<a href="/Category/Delete/' + data + '" class="btn btn-danger my-2 ml-1 categorypopup"  title="Delete Category"><i class="far fa-trash-alt mr-1"></i>Delete</a>';
						}

					}
				],
			"language":
			{
				"emptyTable": "No data found , please click on <b>Add Categories</b> Button to Add Category"

			}

		}
	);

	var scTable = $('#SubcategoryTable').DataTable(
		{
			"ajax":
			{
				"url": "/Subcategory/GetSubcategories",
				"type": "GET",
				"dataType": "json"
			},
			"columns":
				[
					{ "data": "SubcategoryName" },
					{
						"title": "Actions",
						"data": "SubcategoryID",
						"searchable": false,
						"sortable": false,
						"render": function (data, type, full, meta) {
							return '<a href="/Subcategory/Edit?id=' + data + '" class="btn btn-info my-2 mr-1 Subcategorypopup"  title="Edit Subcategory"><i class="fas fa-user-edit mr-1"></i>Edit</a>' +
								'<a href="/Subcategory/Delete/' + data + '" class="btn btn-danger my-2 ml-1 Subcategorypopup"  title="Delete Subcategory"><i class="far fa-trash-alt mr-1"></i>Delete</a>';
						}

					}
				],
			"language":
			{
				"emptyTable": "No data found , please click on <b>Add Categories</b> Button to Add Subcategory"

			}

		}
	);

	var gTable = $('#grievanceTable').DataTable(
		{
			"ajax":
			{
				"url": "/Grievance/GetAllGrievances",
				"type": "GET",
				"dataType": "json"
			},
			"columns":
				[
					{ "data": "Subject" },
					{ "data": "Description" },
					{
						"data": "ReportedDate",
						"render": function (jsonDate) {
							if (jsonDate == "/Date(-62135596800000)/") {
								return "N/A";
							}
							else {
								var date = new Date(parseInt(jsonDate.substr(6)));
								var month = date.getMonth() + 1;
								return date.getDate() + "/" + month + "/" + date.getFullYear();
							}

						}
					},
					{ "data": "Status" },
					{
						"title": "Actions",
						"data": "GrievanceID",
						"searchable": false,
						"sortable": false,
						"render": function (data, type, full, meta) {
							return '<a href="/Grievance/Details?id=' + data + '" class="btn btn-outline-info"  title="Grievance Details">View</a>'
							// +'<a href="/Grievance/Delete/' + data + '" class="btn btn-danger my-2 mx-2 grievancepopup"  title="Delete Grievance">Delete</a>';
						}

					}

				],
			"language":
			{
				"emptyTable": "No data found"

			}

		}
	);

	var dd_c = $("#ddc_Category");

	dd_c.on('change', function () {
		var id = $(this).val();

		scTable.ajax.url("/Subcategory/GetSubcategoriesByCategoryId/" + id).load();
		scTable.draw();
	});


	$('.tablecontainer').on('click', 'a.popup', function (e) {
		e.preventDefault();
		var url = $(this).attr('href');
		var title = $(this).attr('title');
		OpenPopup(url, title, oTable);
	})

	$('.studentcontainer').on('click', 'a.studentpopup', function (e) {
		e.preventDefault();
		var url = $(this).attr('href');
		var title = $(this).attr('title');
		OpenPopup(url, title, sTable);
	})

	$('.categorycontainer').on('click', 'a.categorypopup', function (e) {
		e.preventDefault();
		var url = $(this).attr('href');
		var title = $(this).attr('title');
		OpenPopup(url, title, cTable);
	})

	$('.Subcategorycontainer').on('click', 'a.Subcategorypopup', function (e) {
		e.preventDefault();
		var url = $(this).attr('href');
		var title = $(this).attr('title');
		OpenPopup(url, title, scTable);
	})

	$('.grievancecontainer').on('click', 'a.grievancepopup', function (e) {
		e.preventDefault();
		var url = $(this).attr('href');
		var title = $(this).attr('title');
		OpenPopup(url, title);
	})

	function OpenPopup(pageUrl, elementTitle, tblref) {

		var $pageContent = $('<div />');
		$pageContent.load(pageUrl, function () {
			$('#RegistrationForm', $pageContent).removeData('validator');
			$('#RegistrationForm', $pageContent).removeData('unobtrusiveValidation');
			$.validator.unobtrusive.parse('form');

		});

		$dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
			.html($pageContent)
			.dialog({
				draggable: true,
				autoOpen: false,
				resizable: false,
				model: true,
				title: elementTitle,
				height: 500,
				width: 700,
				close: function () {
					$dialog.dialog('destroy').remove();
				}
			})

		$('.popupWindow').on('submit', '#RegistrationForm', function (e) {
			var url = $('#RegistrationForm')[0].action;
			$.ajax({
				type: "POST",
				url: url,
				data: $('#RegistrationForm').serialize(),
				success: function (data) {
					if (data.result) {
						$dialog.dialog('close');
						tblref.ajax.reload();

						$.notify(data.message,
							{
								// position defines the notification position though uses the defaults below
								globalPosition: 'top center',
								className: 'success',
								autoHideDelay: 3000,
							}

						);
					}
					else {
						$dialog.dialog('close');
						$.notify(data.message,
							{
								// position defines the notification position though uses the defaults below
								globalPosition: 'top center',
								className: 'error',
								autoHideDelay: 3000,
							}

						);
					}
				}
			})

			e.preventDefault();
		})
		$dialog.dialog('open');
	}

	$('#Image').on('change', function (event) {

		$(this).next('.custom-file-label').html(event.target.files[0].name);

	});


});

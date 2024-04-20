function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:51326/api/TeacherData/AddTeacher
	//with POST data of teacher name, employee number, salary etc.

	var URL = "http://localhost:51326/api/AuthorData/AddAuthor/";

	var rq = new XMLHttpRequest();
	

	var TfName = document.getElementById('TfName').value;
	var TlName = document.getElementById('TlName').value;
	var Tnumber = document.getElementById('Tnumber').value;
	var Thiredate = document.getElementById('Thiredate').value;
	var Tsalary = document.getElementById('Tsalary').value;



	var TeacherData = {
		"TfName": TfName,
		"TlName": TlName,
		"Tnumber": Tnumber,
		"Thiredate": Thiredate,
		"Tsalary": Tsalary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}



function UpdateTeacher(TeacherId) {

	//goal: send a request which looks like this:
	//POST : http://localhost:51326/api/TeacherData/UpdateTeacher/{id}
	//with POST data of teacher name, employee number, salary etc.

	var URL = "http://localhost:51326/api/TeacherData/UpdateTeacher/" + TeacherId;

	var rq = new XMLHttpRequest();
	

	var TfName = document.getElementById('TfName').value;
	var TlName = document.getElementById('TlName').value;
	var Tnumber = document.getElementById('Tnumber').value;
	var Thiredate = document.getElementById('Thiredate').value;
	var Tsalary = document.getElementById('Tsalary').value;




	var TeacherData = {
		"TfName": TfName,
		"TlName": TlName,
		"Tnumber": Tnumber,
		"Thiredate": Thiredate,
		"Tsalary": Tsalary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}
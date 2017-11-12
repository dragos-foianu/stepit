

function runTest()
{
	login()
}


function login()
{
	r = $.ajax({
		url: "http://localhost:8080/api/login",
		type: "GET",
		data: {
			name: "Dragos",
			pass: "test"
		},
		crossDomain: true,
		dataType: 'json',
		success: function(res) {
			console.log(res)
			log = document.getElementById('log')

			msg = document.createElement('div')
			msg.innerHTML = "Logged in as Dragos:test, token: " + res;

			log.appendChild(msg)
		}
	});
}
import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import { useSyncExternalStore } from 'react';


const apiUrl = 'http://localhost:57654/api/students/';

function App() {
  const [email, setEmail] = useState('');
  const [pass, setPass] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);



  const btnLogin = () => {
    const studentLoginDetail = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
      Email: email,
      Password: pass
    };

    fetch(apiUrl, {
      method: 'POST',
      body: JSON.stringify(studentLoginDetail),
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
        'Accept': 'application/json; charset=UTF-8' //very important to add the 'charset=UTF-8'!!!!
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log(res.ok);
        console.log(res.status == 200);
        if (res.ok) {
          setIsLoggedIn(true);
          return res.json()
        }
        else
        setIsLoggedIn(false);
          return null;

      })
      .then(
        (result) => {
          if (result == null) {
            return;
          }
          console.log("fetch POST= ", result);
          console.log(result.Id);

        },
        (error) => {
          console.log("err post=", error);
        });
  }

  return (
    <div className="App">
      <header className="App-header">
        Email: <input type="text" onChange={(text) => setEmail(text.target.value)} /> <br />
        Password: <input type="password"  onChange={text => setPass(text.target.value)} /> <br />
        <button onClick={btnLogin} >Login</button>
        u r {isLoggedIn ? "":" not "  }logged in
      </header>
    </div>
  );
}

export default App;

import React, { Component } from 'react';
const BASE_URL = 'https://localhost:5001/api/';
export default class Todos extends Component {
    state = { todos: [] }
  
// Executes when button pressed.
submitToDo(e) {
    const description   = this.ToDo.value;
    this.ToDo.value = ""; // Clear input.     
    fetch(BASE_URL+'todo', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            IsComplete:  false, // Set default to false.
            Description: description,
        })
    })

    // Response received.
    .then(response => response.json())
        // Data retrieved.
        .then(json => {
            console.log(JSON.stringify(json));
            this.fetchTodos();
        })
        // Data not retrieved.
        .catch(function (error) {
            console.log(error);
        }) 
}

delete(id) {
    fetch(BASE_URL + 'todo/MyDelete?Id=' + id, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        }
    })        
    .then(response => response.json())
        // Data retrieved.
        .then(json => {
            console.log(JSON.stringify(json));
            this.fetchTodos();
        })
        // Data not retrieved.
        .catch(function (error) {
            console.log(error);
        })             
}

    fetchTodos() {
        fetch(BASE_URL+'todo')
        .then(response => response.json())
        .then((data) => {
            this.setState({ todos: data });
        })
        .catch ((err) => {
            console.log(`An error has occurred: ${err}`);
      });
    }

    updateToDo(id, checked) {
        fetch(BASE_URL + 'todo/MyEdit', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Id: id,
                IsComplete:  checked
            })
        })
        // Wait for response.   
        .then(response => response.json())
            // Data retrieved.
            .then(json => {
                console.log(JSON.stringify(json));
                this.fetchTodos();
            })
            // Data not retrieved.
            .catch(function (error) {
                console.log(error);
            }) 
    }    
  
    componentDidMount = () => {
        this.submitToDo = this.submitToDo.bind(this);
        this.fetchTodos();
    }
  

    render() {
      return (
        <div>
            <h1>To Do</h1>
            <input type="text" ref={(toDoInput) => this.ToDo = toDoInput} />
            <button onClick={this.submitToDo}>Submit</button>
            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Description</th>
                        <th>Is Complete</th>
                        <th>Priority</th>
                        <th>Created On</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.todos.map(todo =>
                        <tr key={todo.id}>
                            <td>{todo.id}</td>
                            <td>{todo.description}</td>
                            <td>{todo.priority}</td>
                            <td>{todo.isComplete}</td>
                            <td>{todo.createdOn}</td>
                            <td><a href="#" onClick={(e) => this.delete(todo.id)}>Delete</a></td>
                            <td>
                             <input  type='checkbox'value={todo.isComplete} checked={todo.isComplete} onChange={(e) => this.updateToDo(todo.id, e.target.checked)} /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
      )
    }
  }

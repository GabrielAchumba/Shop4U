import { $http } from 'boot/axios' 

const state = {
  inputdeckmodels: [],
  inputdecknames: [],
  selectedinputdeckname: "",
    newinputdeck: {
        departmentName: "",
        facultyName: ""
    },
  showcreateinputdeckdialog:false,
    editedinputdeck: {
        departmentName: "",
        facultyName: ""
    },
    showupdateinputdeckdialog:false,
    editedIndex: 0
}


const getters = {
    inputdeckmodels (state) {
    return state.inputdeckmodels;
  },
  inputdecknames (state) {
    return state.inputdecknames;
  },
  selectedinputdeckname (state) {
    return state.selectedinputdeckname;
  },
  newinputdeck (state){
    return state.newinputdeck;
  },
  showcreateinputdeckdialog (state) {
    return state.showcreateinputdeckdialog;
  },
  editedinputdeck (state){
    return state.editedinputdeck;
  },
  showupdateinputdeckdialog (state) {
    return state.showupdateinputdeckdialog;
  },
  editedIndex(state) {
    return state.editedIndex;
  }

}

const mutations = {
    setInputDeckDateStamp(state, payload){
        state.inputdecknames = payload
    },
    setinputdeckmodels(state, payload){
        state.inputdeckmodels = payload
    },
    setFaculties (state, faculties) {
        state.faculties = faculties
        if(faculties.length > 0){
            state.newFaculty = faculties[0];
            state.SelectedfacultyName=state.faculties[0].facultyName;
            state.facultiesNames = [];
            
            state.departments = [];
            state.departmentsNames = [];
            var i;
            for (i = 0; i < state.faculties.length; i++) {

                var hasMatch = state.facultiesNames.some(function(facultyName) {
                return facultyName === state.faculties[i].facultyName;
            });
            if (hasMatch == false) {
                state.facultiesNames.push(state.faculties[i].facultyName);
            }
                
                if(state.faculties[i].facultyName == state.newFaculty.facultyName){
                    state.departments.push(state.faculties[i]);
                    state.departmentsNames.push(state.faculties[i].departmentName);
                    console.log(i);
                }
               
            }
            //state.departments = state.faculties.find(faculty => faculty.facultyName == state.newFaculty.facultyName); 
        }      
  },
  onFacultyValueChanged(state,ActivefacultyName) {
      var i;
    state.departments = [];
    state.departmentsNames = [];
    for (i = 0; i < state.faculties.length; i++) {
        //console.log("done");
        if(state.faculties[i].facultyName == ActivefacultyName){
            state.departments.push(state.faculties[i]);
            state.departmentsNames.push(state.faculties[i].departmentName);
            //console.log("done");
        }
    }
  },
  setDepartments(state) {
    state.departments = states.faculties.find(faculty => faculty.facultyName == state.newFaculty.facultyName);
  },
  addFaculty (state, faculty) {
    state.faculties.push(faculty);
    state.newFaculty = faculty;
    state.showCreateFacultyDialog = false;
  },
  setshowCreateFacultyDialog(state){
    state.showCreateFacultyDialog = true;
  },
  cancelFacultyCreation(state){
    state.showCreateFacultyDialog = false;
  },
  showselectedFaculty(state,selectedFaculty){
    state.editedIndex = state.faculties.indexOf(selectedFaculty);
    state.editedFaculty = selectedFaculty;
    state.showUpdateFacultyDialog = true;
 },
 updateFaculty (state, faculty) {
    Object.assign(state.faculties[state.editedIndex], faculty);
    state.showUpdateFacultyDialog = false;
  },
  cancelupdateFaculty(state){
    state.showUpdateFacultyDialog = false;
  },
  deleteFaculty(state, faculty){
    const index = state.faculties.indexOf(faculty);
    state.faculties.splice(index, 1)  

  }
}

const actions = {
  
  getinputdeckmodels (context) {  
    return new Promise((resolve, reject) => {
      $http.get('InputDeckDateStamp')
        .then(response => {
            
          context.commit('setInputDeckDateStamp', response.data)                
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
},
getinputdeckmodels (context) {  
    return new Promise((resolve, reject) => {
      $http.get('InputDecks')
        .then(response => {
            
          context.commit('setinputdeckmodels', response.data)                
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
},
createInputDeck (context) {  
  return new Promise((resolve, reject) => {
    $http.post('InputDecks', context.state.newinputdeck)
      .then(response => {

        context.commit('addInputDecks', response.data)                
          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })
},
updateInputDeck (context) {  
  return new Promise((resolve, reject) => {
    var oldInputDeck = context.state.inputdeckmodels[context.state.editedIndex];
      var id = oldInputDeck.id;
      Object.assign(oldInputDeck, context.state.editedinputdeck);
    $http.put('InputDecks/'+ id, oldInputDeck)
      .then(response => {

        context.commit('updateInputDeck', response.data)                
          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })
},
deleteInputDeck (context,payload) {  
  return new Promise((resolve, reject) => {
      
    $http.delete('InputDecks/'+ payload.id)
      .then(response => {

        context.commit('deleteInputDeck', payload)                
          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })
}

}


export default {
  namespaced: true,
  getters,
  mutations,
  actions,
  state
}

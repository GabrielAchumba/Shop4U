import { $http } from 'boot/axios' 

const state = {
  inputdeckmodels: [],
  inputdeckmodelsformatted: [],
  inputdecknames: [],
  inputdecknamesforematted: [],
  selectedinputdeckname: "",
    newinputdeck: {
    },
  showcreateinputdeckdialog:false,
    editedinputdeck: {
    },
    showupdateinputdeckdialog:false,
    editedIndex: 0,
    filemodel: null
}


const getters = {
    inputdeckmodels (state) {
    return state.inputdeckmodels;
  },
  inputdeckmodelsformatted(state){
    return state.inputdeckmodelsformatted;
  },
  inputdecknames (state) {
    return state.inputdecknames;
  },
  inputdecknamesforematted(state){
      return state.inputdecknamesforematted;
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
  },
  filemodel(state){
    return state.filemodel;
  }

}

const mutations = {
    setInputDeckDateStamp(state, payload){
        state.inputdecknames = payload
        
        if(state.inputdecknames.length > 0){

            state.inputdecknamesforematted = [];
            var i;
            for (i = 0; i < state.inputdecknames.length; i++) {

                var hasMatch = state.inputdecknamesforematted.some(function(deckNameStamp) {
                return deckNameStamp === state.inputdecknames[i].inputDeckName;
            });
            if (hasMatch == false) {
                state.inputdecknamesforematted.push(state.inputdecknames[i].inputDeckName);
            }
        }

        }
    },
    setinputdeckmodels(state, payload){
        state.inputdeckmodels = payload
    },
    setinputdeckmodelsformatted(state, payload){
      state.inputdeckmodelsformatted=payload;
    },
  setDepartments(state) {
    state.departments = states.faculties.find(faculty => faculty.facultyName == state.newFaculty.facultyName);
  },
  addInputDeck (state, inputdeck) {
    state.inputdeckmodels.push(inputdeck);
    state.newinputdeck = inputdeck;
    state.showcreateinputdeckdialog = false;
  },
  setshowcreateinputdeckdialog(state){
    state.showcreateinputdeckdialog = true;
  },
  cancelInputdeckCreation(state){
    state.showcreateinputdeckdialog = false;
  },
  showselectedInputdeck(state,selectedInputdeck){
    state.editedIndex = state.inputdeckmodels.indexOf(selectedInputdeck);
    state.editedinputdeck = selectedInputdeck;
    state.showupdateinputdeckdialog = true;
 },
 updateInputDeck (state, inputdeck) {
    Object.assign(state.inputdeckmodels[state.editedIndex], inputdeck);
    state.showupdateinputdeckdialog = false;
  },
  cancelupdateInputdeck(state){
    state.showupdateinputdeckdialog = false;
  },
  deleteInputDeck(state, inputdeck){
    const index = state.inputdeckmodels.indexOf(inputdeck);
    state.inputdeckmodels.splice(index, 1)  

  }
}

const actions = {
  
  getInputDeckDateStamp (context) {  
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
getinputdeckmodels (context, id) {  
    return new Promise((resolve, reject) => {

      $http.get('InputDecks/'+ id)
        .then(response => {
            
          context.commit('setinputdeckmodels', response.data)                
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })

    })
},
getinputdeckmodels2 (context) {  
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

  var result=  new Promise((resolve, reject) => {
    $http.post('InputDecks', context.state.newinputdeck)
      .then(response => {

        context.commit('addInputDeck', response.data)                
          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })

  return result;
},
SaveInputDeck (context) {  
  console.log("yes")
  var i;
  var result=null;
  context.state.inputdeckmodels = [];
  //for (i = 0; i < context.state.inputdeckmodelsformatted.length; i++) {
    result=  new Promise((resolve, reject) => {
    $http.post('InputDecks/saveinputdeck', {
      decks: context.state.inputdeckmodelsformatted
      })
      .then(response => {

        context.commit('addInputDeck', response.data)
        console.log(response.data)                
          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })
//}

  return result;
},
createInputDeck2 (context, payload) {  
  //console.log("Yes")
  var data = new FormData();
  return new Promise((resolve, reject) => {
    $http.post('InputDecks/upload')
      .then(response => {
        context.commit('setinputdeckmodelsformatted', response.data.inputDecks)         
        //console.log(response) 

          resolve(response)
          
      })
      .catch(error => {
        reject(error)
      })
  })
},
getListOfWorkSheetNames (context, file) {  
  
  $http.post('InputDecks/upload', file,{
    headers: { 'Content-Type': undefined},
  })
    .then(function (response) {
      if (response.data.ok) {
      }
    }.bind(this));
    
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
},
onInputdeckstampValueChanged(context,payload){
  var i
  for (i = 0; i < state.inputdecknames.length; i++) {
    if(context.state.inputdecknames[i].inputDeckName == payload){
      context.dispatch('onInputdeckstampValueChanged', context.state.inputdecknames[i].id);
       
    }
}
  
}

}


export default {
  namespaced: true,
  getters,
  mutations,
  actions,
  state
}

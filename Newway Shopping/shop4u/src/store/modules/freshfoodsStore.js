import { $http } from 'boot/axios' 

const state = {
    FreshFoods: [],
    SelectedFreshFood: {},
    DoesFreshFoodExists: false,
    NewFreshFood:{},
    SelectedIndex: 0,
    showUpdateDialog:false,
    showCreateDialog: false
  }

  const getters = {
    FreshFoods (state) {
    return state.FreshFoods;
  },
  SelectedFreshFood(state){
    return state.SelectedFreshFood;
  },
  DoesFreshFoodExists(state){
    return state.DoesFreshFoodExists;
  },
  NewFreshFood(state){
    return state.NewFreshFood;
  },
  showUpdateDialog(state){
    return state.showUpdateDialog;
  },
  showCreateDialog(state){
    return state.showCreateDialog;
  }
}

const mutations = {

  GetFreshFoods(state, payload){
        state.FreshFoods = payload
  },
  FindSelectedGood(state, payload)
  {
    state.DoesFreshFoodExists = false;

    for(var prop in payload) {
      if(obj.hasOwnProperty(prop))
      {
        state.DoesFreshFoodExists=true;
        break;
      }        
  }
  
  },
  CreateGood(state, payload)
  {
    state.FreshFoods.push(payload);
    state.NewFreshFood = payload;
    state.showCreateDialog=false;
  },
  UpdateGood(state, payload)
  {
    Object.assign(state.FreshFoods[state.editedIndex], payload);
    state.showUpdateDialog=false;
  },
  showCreateDialogFunction(state)
  {
    state.showCreateDialog=true;
  },
  showUpdateDialogFunction(state)
  {
    state.showUpdateDialog=true;
  }

}

const actions = {

    GetFreshFoods (context) {  
        return new Promise((resolve, reject) => {
          $http.get('GoodDetails/GetFreshFoods')
            .then(response => {
                
              context.commit('GetFreshFoods', response.data)              
                resolve(response)
                
            })
            .catch(error => {
              reject(error)
            })
        })
    },
    FindSelectedGood (context) {  
      return new Promise((resolve, reject) => {
        $http.post('GoodDetails/FindSelectedGood', context.state.SelectedFreshFood)
          .then(response => {
              
            context.commit('FindSelectedGood', response.data)              
              resolve(response)
              
          })
          .catch(error => {
            reject(error)
          })
      })
  },
  CreateGood(context, payload)
  {
    return new Promise((resolve, reject) => {
      var customerId_ticketId = payload.customerId + "*" +payload.ticketId;
      context.state.NewFreshFood.customersIds =  context.state.NewFreshFood.customersIds + "?" + customerId_ticketId;
      $http.post('GoodDetails/CreateGood', context.state.NewFreshFood)
        .then(response => {
            
          context.commit('CreateGood', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
  },
  UpdateGood(context, payload)
  {
    return new Promise((resolve, reject) => {
      var oldFreshFood = context.state.FreshFoods[context.state.SelectedIndex];
      var id = oldFreshFood.id;
      Object.assign(oldFreshFood, context.state.SelectedFreshFood);

      var customerId_ticketId = payload.customerId + "*" +payload.ticketId;
      oldFreshFood.customersIds =  oldFreshFood.customersIds + "?" + customerId_ticketId;
      $http.put('GoodDetails/PutGood'+ id, oldFreshFood)
        .then(response => {
            
          context.commit('UpdateGood', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
  },
  RemoveGoodTicket(context,payload)
  {
    return new Promise((resolve, reject) => {
      //payload convert the customer Id from Guid to string

var CustomersIdsTickeksIds = context.state.SelectedFreshFood.customersIds.split('?');
var NewCustomersIdsTickeksIds="";

for(i = 0; i < CustomersIdsTickeksIds.length; i++){
  var CustomerIdTickeksId = mySplitResult[i].split("*");
  if(CustomerIdTickeksId[0] != payload)
  {
    var NewCustomerIdTickeksId = CustomerIdTickeksId[0] + "*" + CustomerIdTickeksId[1];
    NewCustomersIdsTickeksIds = NewCustomersIdsTickeksIds + "?" + NewCustomerIdTickeksId;
  }
}

      var oldFreshFood = context.state.FreshFoods[context.state.SelectedIndex];
      var id = oldFreshFood.id;
      Object.assign(oldFreshFood, context.state.SelectedFreshFood);

      oldFreshFood.customersIds = NewCustomersIdsTickeksIds;

      $http.put('GoodDetails/PutGood'+ id, oldFreshFood)
        .then(response => {
            
          context.commit('UpdateGood', response.data)              
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
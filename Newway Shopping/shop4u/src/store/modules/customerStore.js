import { $http } from 'boot/axios' 

const state = {
    NewCustomer:{}
  }

  const getters = {
    NewCustomer (state) {
    return state.NewCustomer;
  }
}

const mutations = {

  CreateNewCustomer(state, payload){
        state.NewCustomer = payload
  }

}

const actions = {

    CreateNewCustomer(context)
  {
    return new Promise((resolve, reject) => {
       $http.post('Customers', context.state.NewCustomer)
        .then(response => {
            
          context.commit('CreateNewCustomer', response.data)              
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
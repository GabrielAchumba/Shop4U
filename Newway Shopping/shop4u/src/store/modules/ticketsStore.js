import { $http } from 'boot/axios' 

const state = {
    NewTicket:{}
  }

  const getters = {
    NewTicket (state) {
    return state.NewTicket;
  }
}

const mutations = {

  CreateNewTicket(state, payload){
        state.NewTicket = payload
  }

}

const actions = {

  CreateNewTicket(context)
  {
    return new Promise((resolve, reject) => {
       $http.post('ItemTickets', context.state.NewTicket)
        .then(response => {
            
          context.commit('CreateNewTicket', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
  },
  DeleteSelectedTicket (context,TicketId) {  
    return new Promise((resolve, reject) => {
        
      $http.delete('ItemTickets/DeleteItemTicketByStringId/'+ TicketId)
        .then(response => {

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
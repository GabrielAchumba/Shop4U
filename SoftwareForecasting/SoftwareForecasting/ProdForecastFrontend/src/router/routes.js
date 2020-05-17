/* import AdminLayout from '../layouts/AdminLayout.Vue'
import Index from '../pages/Index.Vue';

const routes = [
  {
    path: '/', component: AdminLayout,
    children: [
      { path: '', component: Index}
    ]
  }
] */

const routes = [
  {
    path: '/',
    component: () => import('layouts/AdminLayout.vue'),
    children: [
      { 
        path: '', 
        component: () => import('pages/index.vue') 
      },
      { 
        path: '/inputdeckList', 
        component: () => import('pages/inputdeck/inputdeckList.vue') 
      },
      { 
        path: '/optimization', 
        component: () => import('pages/optimization/runforecast.vue') 
      },
      { 
        path: '/dataimport', 
        component: () => import('pages/dataImport/importinputdeck.vue') 
      }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes

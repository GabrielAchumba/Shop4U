
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { 
        path: '', 
        component: () => import('pages/home/index.vue') 
      },
      { 
        path: '/freshfoods', 
        component: () => import('pages/freshfoods/index.vue') 
      },
      { 
        path: '/provisions', 
        component: () => import('pages/provisions/index.vue') 
      },
      { 
        path: '/household_appliances', 
        component: () => import('pages/household_appliances/index.vue') 
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

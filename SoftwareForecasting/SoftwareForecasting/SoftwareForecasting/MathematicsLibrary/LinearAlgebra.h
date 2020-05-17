#pragma once

#ifndef LINEARALGEBRA_H
#define LINEARALGEBRA_H




#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <iomanip>
#include <time.h>
#include <functional>
#include <math.h>
#include "MathsUtils.h"
#include "MathematicsLibrary.h"


using namespace std;


template<typename T, typename U>
class  LinearAlgebra
{


private:
#define SWAP(a,b) {temp=(a);(a)=(b);(b)=temp;}
#define TINY 1.0e-20

	MathsUtils util;

public:


	void gaussj(T** a, U n, T** b, U m);

	void ludcmp(T** a, U n, int* indx, T* d);

	void lubksb(T** a, U n, int* indx, T b[]);

	void lu_minverse(T** a, U n, int* indx, T* d, T** y, T* col);

	void lu_determinant(T** a, U n, int* indx, T* d, T& det);

	void tridag(T a[], T b[], T c[], T r[], T u[], unsigned long n);

	void banmul(T** a, unsigned long n, U m1, U m2, T x[], T b[]);

	void bandec(T** a, unsigned long n, U m1, U m2, T** al,
		unsigned long indx[], T* d);

	void banbks(T** a, unsigned long n, U m1, U m2, T** al,
		unsigned long indx[], T b[]);

	void mprove(T** a, T** alud, U n, U indx[], T b[], T x[]);

	void svbksb(T** u, T w[], T** v, U m, U n, T b[], T x[]);

	T pythag(T a, T b);

	void svdcmp(T** a, U m, U n, T w[], T** v);


};
#endif // !LINEARALGEBRA_H

template<typename T, typename U>
void LinearAlgebra<T, U>::gaussj(T** a, U n, T** b, U m)
{
	int* indxc, * indxr, * ipiv;
	int i, icol, irow, j, k, l, ll;
	T big, dum, pivinv, temp;

	indxc = util.ivector(1, n);
	indxr = util.ivector(1, n);
	ipiv = util.ivector(1, n);

	for (j = 1; j <= n; j++) ipiv[j] = 0;
	for (i = 1; i <= n; i++) {
		big = 0.0;
		for (j = 1; j <= n; j++)
			if (ipiv[j] != 1)
				for (k = 1; k <= n; k++) {
					if (ipiv[k] == 0) {
						if (fabs(a[j][k]) >= big) {
							big = fabs(a[j][k]);
							irow = j;
							icol = k;
						}
					}
				}
		++(ipiv[icol]);
		if (irow != icol) {
			for (l = 1; l <= n; l++) SWAP(a[irow][l], a[icol][l])
				for (l = 1; l <= m; l++) SWAP(b[irow][l], b[icol][l])
		}
		indxr[i] = irow;
		indxc[i] = icol;
		if (a[icol][icol] == 0.0) util.nrerror("gaussj: Singular Matrix");
		pivinv = 1.0 / a[icol][icol];
		a[icol][icol] = 1.0;
		for (l = 1; l <= n; l++) a[icol][l] *= pivinv;
		for (l = 1; l <= m; l++) b[icol][l] *= pivinv;
		for (ll = 1; ll <= n; ll++)
			if (ll != icol) {
				dum = a[ll][icol];
				a[ll][icol] = 0.0;
				for (l = 1; l <= n; l++) a[ll][l] -= a[icol][l] * dum;
				for (l = 1; l <= m; l++) b[ll][l] -= b[icol][l] * dum;
			}
	}

	for (l = n; l >= 1; l--) {
		if (indxr[l] != indxc[l])
			for (k = 1; k <= n; k++)
				SWAP(a[k][indxr[l]], a[k][indxc[l]]);
	}

	util.free_ivector(ipiv, 1, n);
	util.free_ivector(indxr, 1, n);
	util.free_ivector(indxc, 1, n);


}

template<typename T, typename U>
void LinearAlgebra<T, U>::ludcmp(T** a, U n, int* indx, T* d)
{
	int i, imax, j, k;
	T big, dum, sum, temp;
	T* vv;

	vv = util.dvector(1, n);
	*d = 1.0;

	for (i = 1; i <= n; i++) {
		big = 0.0;
		for (j = 1; j <= n; j++)
			if ((temp = fabs(a[i][j])) > big) big = temp;
		if (big == 0.0) util.nrerror("Singular matrix in routine ludcmp");
		vv[i] = 1.0 / big;
	}

	for (j = 1; j <= n; j++) {
		for (i = 1; i < j; i++) {
			sum = a[i][j];
			for (k = 1; k < i; k++) sum -= a[i][k] * a[k][j];
			a[i][j] = sum;
		}
		big = 0.0;
		for (i = j; i <= n; i++) {
			sum = a[i][j];
			for (k = 1; k < j; k++)
				sum -= a[i][k] * a[k][j];
			a[i][j] = sum;
			if ((dum = vv[i] * fabs(sum)) >= big) {
				big = dum;
				imax = i;
			}
		}
		if (j != imax) {
			for (k = 1; k <= n; k++) {
				dum = a[imax][k];
				a[imax][k] = a[j][k];
				a[j][k] = dum;
			}
			*d = -(*d);
			vv[imax] = vv[j];
		}
		indx[j] = imax;
		if (a[j][j] == 0.0) a[j][j] = TINY;
		if (j != n) {
			dum = 1.0 / (a[j][j]);
			for (i = j + 1; i <= n; i++) a[i][j] *= dum;
		}
	}

	util.free_dvector(vv, 1, n);
}

template<typename T, typename U>
void LinearAlgebra<T, U>::lubksb(T** a, U n, int* indx, T b[])
{
	int i, ii = 0, ip, j;
	float sum;
	for (i = 1; i <= n; i++) {
		ip = indx[i];
		sum = b[ip];
		b[ip] = b[i];
		if (ii)
			for (j = ii; j <= i - 1; j++) sum -= a[i][j] * b[j];
		else if (sum) ii = i;
		b[i] = sum;
	}
	for (i = n; i >= 1; i--) {
		sum = b[i];
		for (j = i + 1; j <= n; j++) sum -= a[i][j] * b[j];
		b[i] = sum / a[i][i];
	}
}

template<typename T, typename U>
void LinearAlgebra<T, U>::lu_minverse(T** a, U N, int* indx, T* d, T** y, T* col)
{
	int i, j;

	ludcmp(a, N, indx, d);
	for (j = 1; j <= N; j++) {
		for (i = 1; i <= N; i++) col[i] = 0.0;
		col[j] = 1.0;
		lubksb(a, N, indx, col);
		for (i = 1; i <= N; i++) y[i][j] = col[i];
	}
}

template<typename T, typename U>
void LinearAlgebra<T, U>::lu_determinant(T** a, U N, int* indx, T* d, T& det)
{
	int j;
	det = 1.0;
	ludcmp(a, N, indx, d);
	for (j = 1; j <= N; j++)
		det *= a[j][j];
}

template<typename T, typename U>
void LinearAlgebra<T, U>::tridag(T a[], T b[], T c[], T r[], T u[], unsigned long n)
{
	unsigned long j;
	T bet, * gam;
	gam = util.dvector(1, n);
	if (b[1] == 0.0) util.nrerror("Error 1 in tridag");
	u[1] = r[1] / (bet = b[1]);
	for (j = 2; j <= n; j++) {
		gam[j] = c[j - 1] / bet;
		bet = b[j] - a[j] * gam[j];
		if (bet == 0.0) util.nrerror("Error 2 in tridag");
		u[j] = (r[j] - a[j] * u[j - 1]) / bet;
	}
	for (j = (n - 1); j >= 1; j--)
		u[j] -= gam[j + 1] * u[j + 1];
	util.free_dvector(gam, 1, n);
}

template<typename T, typename U>
void LinearAlgebra<T, U>::banmul(T** a, unsigned long n, U m1, U m2, T x[], T b[])
{
	unsigned long i, j, k, tmploop;
	for (i = 1; i <= n; i++) {
		k = i - m1 - 1;
		tmploop = util.LMIN(m1 + m2 + 1, n - k);
		b[i] = 0.0;
		for (j = util.LMAX(1, 1 - k); j <= tmploop; j++) b[i] += a[i][j] * x[j + k];
	}
}

template<typename T, typename U>
void  LinearAlgebra<T, U>::bandec(T** a, unsigned long n, U m1, U m2, T** al,
	unsigned long indx[], T* d)
{
	unsigned long i, j, k, l;
	int mm;
	T dum;
	mm = m1 + m2 + 1;
	l = m1;
	for (i = 1; i <= m1; i++) {
		for (j = m1 + 2 - i; j <= mm; j++) a[i][j - l] = a[i][j];
		l--;
		for (j = mm - l; j <= mm; j++) a[i][j] = 0.0;
	}
	*d = 1.0;
	l = m1;
	for (k = 1; k <= n; k++) {
		dum = a[k][1];
		i = k;
		if (l < n) l++;
		for (j = k + 1; j <= l; j++) {
			if (fabs(a[j][1]) > fabs(dum)) {
				dum = a[j][1];
				i = j;
			}
		}
		indx[k] = i;
		if (dum == 0.0) a[k][1] = TINY;
		if (i != k) {
			*d = -(*d);
			for (j = 1; j <= mm; j++) SWAP(a[k][j], a[i][j])
		}
		for (i = k + 1; i <= l; i++) {
			Do the elimination.
				dum = a[i][1] / a[k][1];
			al[k][i - k] = dum;
			for (j = 2; j <= mm; j++) a[i][j - 1] = a[i][j] - dum * a[k][j];
			a[i][mm] = 0.0;
		}
	}
}

template<typename T, typename U>
void LinearAlgebra<T, U>::banbks(T** a, unsigned long n, U m1, U m2, T** al,
	unsigned long indx[], T b[])
{
	unsigned long i, k, l;
	int mm;
	T dum;
	mm = m1 + m2 + 1;
	l = m1;
	for (k = 1; k <= n; k++) {
		i = indx[k];
		if (i != k) SWAP(b[k], b[i])
			if (l < n) l++;
		for (i = k + 1; i <= l; i++) b[i] -= al[k][i - k] * b[k];
	}
	l = 1;
	for (i = n; i >= 1; i--) {
		dum = b[i];
		for (k = 2; k <= l; k++) dum -= a[i][k] * b[k + i - 1];
		b[i] = dum / a[i][1];
		if (l < mm) l++;
	}
}

template<typename T, typename U>
void LinearAlgebra<T, U>::mprove(T** a, T** alud, U n, U indx[], T b[], T x[])
{
	//void lubksb(float** a, int n, int* indx, float b[]);
	int j, i;
	T sdp;
	T* r;
	r = vector(1, n);
	for (i = 1; i <= n; i++) {
		sdp = -b[i];
		for (j = 1; j <= n; j++) sdp += a[i][j] * x[j];
		r[i] = sdp;
	}
	lubksb(alud, n, indx, r);
	for (i = 1; i <= n; i++) x[i] -= r[i];
	util.free_dvector(r, 1, n);
}

template<typename T, typename U>
void LinearAlgebra<T, U>::svbksb(T** u, T w[], T** v, U m, U n, T b[], T x[])
{
	int jj, j, i;
	T s, * tmp;
	tmp = vector(1, n);
	for (j = 1; j <= n; j++) {
		s = 0.0;
		if (w[j]) {
			for (i = 1; i <= m; i++) s += u[i][j] * b[i];
			s /= w[j];
		}
		tmp[j] = s;
	}
	for (j = 1; j <= n; j++) {
		s = 0.0;
		for (jj = 1; jj <= n; jj++) s += v[j][jj] * tmp[jj];
		x[j] = s;
	}
	util.free_dvector(tmp, 1, n);
}

template<typename T, typename U>
T LinearAlgebra<T, U>::pythag(T a, T b)
{
	float absa, absb;
	absa = fabs(a);
	absb = fabs(b);
	if (absa > absb) return absa * sqrt(1.0 + util.SQR(absb / absa));
	else return (absb == 0.0 ? 0.0 : absb * sqrt(1.0 + util.SQR(absa / absb)));
}


template<typename T, typename U>
void LinearAlgebra<T, U>::svdcmp(T** a, U m, U n, T w[], T** v)
{
	int flag, i, its, j, jj, k, l, nm;
	T anorm, c, f, g, h, s, scale, x, y, z, * rv1;
	rv1 = util.dvector(1, n);
	g = scale = anorm = 0.0; 
		for (i = 1; i <= n; i++) {
			l = i + 1;
			rv1[i] = scale * g;
			g = s = scale = 0.0;
			if (i <= m) {
				for (k = i; k <= m; k++) scale += fabs(a[k][i]);
				if (scale) {
					for (k = i; k <= m; k++) {
						a[k][i] /= scale;
						s += a[k][i] * a[k][i];
					}
					f = a[i][i];
					g = -util.SIGN(sqrt(s), f);
					h = f * g - s;
					a[i][i] = f - g;
					for (j = l; j <= n; j++) {
						for (s = 0.0, k = i; k <= m; k++) s += a[k][i] * a[k][j];
						f = s / h;
						for (k = i; k <= m; k++) a[k][j] += f * a[k][i];
					}
					for (k = i; k <= m; k++) a[k][i] *= scale;
				}
			}
			w[i] = scale * g;
			g = s = scale = 0.0;
			if (i <= m && i != n) {
				for (k = l; k <= n; k++) scale += fabs(a[i][k]);
				if (scale) {
					for (k = l; k <= n; k++) {
						a[i][k] /= scale;
						s += a[i][k] * a[i][k];
					}
					f = a[i][l];
					g = -util.SIGN(sqrt(s), f);
					h = f * g - s;
					a[i][l] = f - g;
					for (k = l; k <= n; k++) rv1[k] = a[i][k] / h;
					for (j = l; j <= m; j++) {
						for (s = 0.0, k = l; k <= n; k++) s += a[j][k] * a[i][k];
						for (k = l; k <= n; k++) a[j][k] += s * rv1[k];
					}
					for (k = l; k <= n; k++) a[i][k] *= scale;
				}
			}
			anorm = util.DMAX(anorm, (fabs(w[i]) + fabs(rv1[i])));
		}
		for (i = n; i >= 1; i--) {
				if (i < n) {
					if (g) {
						for (j = l; j <= n; j++)
							v[j][i] = (a[i][j] / a[i][l]) / g;
						for (j = l; j <= n; j++) {
							for (s = 0.0, k = l; k <= n; k++) s += a[i][k] * v[k][j];
							for (k = l; k <= n; k++) v[k][j] += s * v[k][i];
						}
					}
					for (j = l; j <= n; j++) v[i][j] = v[j][i] = 0.0;
				}
				v[i][i] = 1.0;
				g = rv1[i];
				l = i;
		}
		for (i = util.LMIN(m, n); i >= 1; i--) {
				l = i + 1;
			g = w[i];
			for (j = l; j <= n; j++) a[i][j] = 0.0;
			if (g) {
				g = 1.0 / g;
				for (j = l; j <= n; j++) {
					for (s = 0.0, k = l; k <= m; k++) s += a[k][i] * a[k][j];
					f = (s / a[i][i]) * g;
					for (k = i; k <= m; k++) a[k][j] += f * a[k][i];
				}
				for (j = i; j <= m; j++) a[j][i] *= g;
			}
			else for (j = i; j <= m; j++) a[j][i] = 0.0;
			++a[i][i];
		}
		for (k = n; k >= 1; k--) {
				for (its = 1; its <= 30; its++) {
						flag = 1;
					for (l = k; l >= 1; l--) {
							nm = l - 1; 
							if ((float)(fabs(rv1[l]) + anorm) == anorm) {
								flag = 0;
								break;
							}
						if ((float)(fabs(w[nm]) + anorm) == anorm) break;
					}
					if (flag) {
						c = 0.0; 
							s = 1.0;
						for (i = l; i <= k; i++) {
							f = s * rv1[i];
							rv1[i] = c * rv1[i];
							if ((float)(fabs(f) + anorm) == anorm) break;
							g = w[i];
							h = pythag(f, g);
							w[i] = h;
							h = 1.0 / h;
							c = g * h;
							s = -f * h;
							for (j = 1; j <= m; j++) {
								y = a[j][nm];
								z = a[j][i];
								a[j][nm] = y * c + z * s;
								a[j][i] = z * c - y * s;
							}
						}
					}
					z = w[k];
					if (l == k) {
							if (z < 0.0) {
									w[k] = -z;
								for (j = 1; j <= n; j++) v[j][k] = -v[j][k];
							}
						break;
					}
					if (its == 30) nrerror("no convergence in 30 svdcmp iterations");
					x = w[l];
					nm = k - 1;
					y = w[nm];
					g = rv1[nm];
					h = rv1[k];
					f = ((y - z) * (y + z) + (g - h) * (g + h)) / (2.0 * h * y);
					g = pythag(f, 1.0);
					f = ((x - z) * (x + z) + h * ((y / (f + util.SIGN(g, f))) - h)) / x;
					c = s = 1.0; 
					for (j = l; j <= nm; j++) {
						i = j + 1;
						g = rv1[i];
						y = w[i];
						h = s * g;
						g = c * g;
						z = pythag(f, h);
						rv1[j] = z;
						c = f / z;
						s = h / z;
						f = x * c + g * s;
						g = g * c - x * s;
						h = y * s;
						y *= c;
						for (jj = 1; jj <= n; jj++) {
							x = v[jj][j];
							z = v[jj][i];
							v[jj][j] = x * c + z * s;
							v[jj][i] = z * c - x * s;
						}
						z = pythag(f, h);
						w[j] = z; 
							if (z) {
								z = 1.0 / z;
								c = f * z;
								s = h * z;
							}
						f = c * g + s * y;
						x = c * y - s * g;
						or (jj = 1; jj <= m; jj++) {
							y = a[jj][j];
							z = a[jj][i];
							a[jj][j] = y * c + z * s;
							a[jj][i] = z * c - y * s;
						}
					}
					rv1[l] = 0.0;
					rv1[k] = f;
					w[k] = x;
				}
		}
		util.free_dvector(rv1, 1, n);
}